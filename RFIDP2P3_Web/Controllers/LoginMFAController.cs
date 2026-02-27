using System.Net;
using System.Text;
using System.Text.Json;
using RFIDP2P3_Web.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace RFIDP2P3_Web.Controllers
{

    [ResponseCache(NoStore = true, Location = ResponseCacheLocation.None)]
    public class LoginMFAController : Controller
    {
        public IActionResult Index()
        {
            var picId = HttpContext.Session.GetString("PIC_ID");
            var mfaVerified = HttpContext.Session.GetString("SESSION_MFA_VERIFIED");
            
            if (picId != null && mfaVerified == "false")
            {
                var config = new ConfigurationBuilder()
                    .AddJsonFile("appsettings.json")
                    .Build();
        
                ViewData["myurl"] = config.GetSection("Path:URL").Value;
                return View();
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }
        
        public async Task<IActionResult> CheckAuth([FromBody] ModelMFA model)
        {
            if (string.IsNullOrWhiteSpace(model.UserId) || string.IsNullOrWhiteSpace(model.OTP))
                return Json(new { status = 0, message = "Invalid input" });
            
            
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("XApiKey", "pgH7QzFHJx4w46fI~5Uzi4RvtTwlEXp");
                var content = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");

                string apiUrl = new ConfigurationBuilder()
                    .AddJsonFile("appsettings.json")
                    .Build()
                    .GetSection("Path:URL").Value;

                string fullUrl = apiUrl.TrimEnd('/') + "/LoginMFA/CheckAuth";
                
                HttpResponseMessage response = null;
                string responseBody = "";
                
                try
                {
                    response = await client.PostAsync(fullUrl, content);
                    responseBody = await response.Content.ReadAsStringAsync();
                }
                catch (Exception httpEx)
                {
                    await LogToFile($"[ERROR] Gagal call API MFA: {httpEx.Message}. Full URL: {fullUrl}");
                    return Json(new { status = 0, message = "Gagal menghubungi server MFA (Periksa log Web)." });
                }
                
                dynamic result = null;
                try
                {
                    result = JsonConvert.DeserializeObject(responseBody);
                }
                catch (Exception ex)
                {
                    responseBody = $"Invalid JSON: {ex.Message}\nRaw: {responseBody}";
                }
                
                try
                {
                    var logText = new StringBuilder();
                    logText.AppendLine($"Timestamp : {DateTime.Now:yyyy-MM-dd HH:mm:ss}");
                    // logText.AppendLine($"URL       : {fullUrl}");
                    logText.AppendLine($"UserId    : {model.UserId}");
                    logText.AppendLine($"Status    : {(int)(response?.StatusCode ?? 0)} {response?.StatusCode}");
                    logText.AppendLine("Body      :");
                    logText.AppendLine(responseBody);
                    logText.AppendLine(new string('-', 80));
                    await LogToFile(logText.ToString());
                }
                catch (Exception logEx)
                {
                    await LogToFile($"[ERROR] Gagal menulis log MFA: {logEx.Message}");
                }
                
                if (response.StatusCode == HttpStatusCode.TooManyRequests)
                {
                    var retryAfterSeconds = 0;
                    if (response.Headers.RetryAfter?.Delta is TimeSpan delta)
                    {
                        retryAfterSeconds = Math.Max(1, (int)Math.Ceiling(delta.TotalSeconds));
                    }
                    else if (response.Headers.TryGetValues("Retry-After", out var vals)
                             && int.TryParse(vals.FirstOrDefault(), out var ra))
                    {
                        retryAfterSeconds = Math.Max(1, ra);
                    }
                    else
                    {
                        try
                        {
                            using var doc = JsonDocument.Parse(responseBody);
                            if (doc.RootElement.TryGetProperty("retryAfter", out var ra2))
                                retryAfterSeconds = Math.Max(1, ra2.GetInt32());
                        }
                        catch { /* ignore */ }
                    }
                    
                    Response.Headers["Retry-After"] = retryAfterSeconds.ToString();
                    // Kembalikan 429 + payload yang simpel
                    return StatusCode(
                        StatusCodes.Status429TooManyRequests,
                        new { error = "Too many requests", retryAfter = retryAfterSeconds }
                    );
                }

                // Evaluasi hasil MFA
                if (result?.status == 1)
                {
                    HttpContext.Session.SetString("SESSION_MFA_VERIFIED", "true");
                    return Json(new { status = 1, data = new { url = Url.Action("Index", "Home") } });
                }
                else
                {
                    string remark = result?.data?.remark ?? result?.message ?? "OTP tidak valid atau gagal login.";
                    return Json(new { status = 0, message = remark });
                }

            }
        }
        
        private async Task LogToFile(string text)
        {
            try
            {
                string logDir = Path.Combine(Directory.GetCurrentDirectory(), "Logs");
                Directory.CreateDirectory(logDir);

                string logPath = Path.Combine(logDir, "MFA.txt");
                await System.IO.File.AppendAllTextAsync(logPath, text + Environment.NewLine);
            }
            catch
            {
                return;
            }
        }


    }
}
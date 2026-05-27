using RFIDP2P3_Web.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;
using System.Net;

namespace RFIDP2P3_Web.Controllers
{
    public class LoginController : Controller
    {
        private readonly IConfiguration _config;
        
        public LoginController(IConfiguration config)
        {
            _config = config;
        }
        
        public IActionResult Index()
        {
            var picId = HttpContext.Session.GetString("PIC_ID");
            var mfaVerified = HttpContext.Session.GetString("SESSION_MFA_VERIFIED");
            
            ViewBag.Message = null;
            ViewBag.User = null;
            
            if (string.IsNullOrEmpty(picId) || mfaVerified == "false")
            {
                ViewData["myurl"] = _config.GetValue<string>("Path:URL");
                return View();
            }

            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public async Task<IActionResult> Index(string username, string password)
        {
            HttpClientHandler clientHandler = new HttpClientHandler();
            HttpClient client = new HttpClient(clientHandler);
            string apiResponse;

            using (client)
            {
                User userLogin = new User();
                userLogin.PIC_ID = username;
                userLogin.password = password;
                StringContent content = new StringContent(JsonConvert.SerializeObject(userLogin), Encoding.UTF8, "application/json");

                // client.DefaultRequestHeaders.Add("XApiKey", "pgH7QzFHJx4w46fI~5Uzi4RvtTwlEXp");

                string clientIp = HttpContext.Connection.RemoteIpAddress?.ToString() ?? "UnknownIP";
                client.DefaultRequestHeaders.Add("X-Forwarded-For", clientIp);

                string myurl = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetSection("Path:URL").Value;
                using (var response = await client.PostAsync(myurl + "Login/Index", content))
                {
                    apiResponse = await response.Content.ReadAsStringAsync();

                    if (response.StatusCode == HttpStatusCode.TooManyRequests)
                    {
                        dynamic? errorResponse = JsonConvert.DeserializeObject(apiResponse);
                        ViewBag.Message = errorResponse?.message ?? "Terlalu banyak percobaan login gagal. Silakan tunggu.";
                        return View();
                    }

                    if (apiResponse == "User not found/not active")
                    {
                        ViewBag.Message = "User not found/not active";
                        return View();
                    }
                    else if (apiResponse == "Incorrect login/password")
                    {
                        ViewBag.Message = "Incorrect login/password";
                        return View();
                    }
                    else
                    {
                        dynamic loginResult = JsonConvert.DeserializeObject(apiResponse);
                        bool requireMfa = loginResult.requireMfa ?? false;
                        User userLoginResult = JsonConvert.DeserializeObject<User>(JsonConvert.SerializeObject(loginResult.user));
                        
                        HttpContext.Session.SetString("PIC_ID", userLoginResult.PIC_ID);
                        HttpContext.Session.SetString("PIC_Name", userLoginResult.PIC_Name);
						HttpContext.Session.SetString("UserGroup_Id", userLoginResult.UserGroup_Id);
						HttpContext.Session.SetString("UserGroup_Name", userLoginResult.UserGroup_Name);
                        if (userLoginResult.Privileges != null)
                        {
                            foreach (var privilege in userLoginResult.Privileges)
                            {
                                HttpContext.Session.SetString("read_" + (privilege.Menu_Id ?? ""), privilege.checkedbox_read ?? "");
                                HttpContext.Session.SetString("add_" + (privilege.Menu_Id ?? ""), privilege.checkedbox_add ?? "");
                                HttpContext.Session.SetString("edit_" + (privilege.Menu_Id ?? ""), privilege.checkedbox_edit ?? "");
                                HttpContext.Session.SetString("del_" + (privilege.Menu_Id ?? ""), privilege.checkedbox_del ?? "");
                            }
                        }
                        
                        if (requireMfa)
                        {
                            HttpContext.Session.SetString("SESSION_MFA_VERIFIED", "false");
                            return RedirectToAction("Index", "LoginMFA");
                        }
                        else
                        {
                            string token = loginResult.token;
                            Response.Cookies.Append("jwt_token", token, new CookieOptions
                            {
                                HttpOnly = true,
                                Secure = true, 
                                SameSite = SameSiteMode.Strict,
                                Expires = DateTimeOffset.UtcNow.AddHours(8)
                            });
                            
                            HttpContext.Session.SetString("SESSION_MFA_VERIFIED", "true");
                            return RedirectToAction("Index", "Home");
                        }
                    }
                }
            }
        }

        public async Task<IActionResult> Logout()
        {
            var token = Request.Cookies["jwt_token"];

            if (!string.IsNullOrEmpty(token))
            {
                try
                {
                    var config = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
                    string apiUrl = config.GetSection("Path:URL").Value ?? "";
                    string fullUrl = apiUrl.TrimEnd('/') + "/Login/Logout";

                    using (var client = new HttpClient())
                    {
                        client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
                        await client.PostAsync(fullUrl, null); 
                    }
                }
                catch { }
            }
            
            HttpContext.Session.Clear();
            Response.Cookies.Delete("jwt_token");

            return RedirectToAction("Index", "Login");
        }
    }
}

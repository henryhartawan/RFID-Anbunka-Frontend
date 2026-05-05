using Microsoft.AspNetCore.Mvc;
using System.Text;
using Newtonsoft.Json;
using System.Net.Http.Headers;

namespace RFIDP2P3_Web.Controllers
{
    public class ApiProxyController : Controller
    {
        private readonly IConfiguration _config;

        public ApiProxyController(IConfiguration config)
        {
            _config = config;
        }

        [Route("ApiProxy/Forward/{*targetPath}")]
        public async Task<IActionResult> Forward(string targetPath)
        {
            var token = Request.Cookies["jwt_token"];
            if (string.IsNullOrEmpty(token))
                return Unauthorized(new { message = "Session expired, please log in again." });

            string baseUrl = _config.GetValue<string>("Path:URL") ?? "";
            string fullUrl = $"{baseUrl.TrimEnd('/')}/{targetPath}";

            using var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            var method = new HttpMethod(Request.Method);
            var requestMessage = new HttpRequestMessage(method, fullUrl);

            if (method != HttpMethod.Get)
            {
                using var reader = new StreamReader(Request.Body);
                var rawJsonBody = await reader.ReadToEndAsync();
                
                if (!string.IsNullOrEmpty(rawJsonBody))
                {
                    requestMessage.Content = new StringContent(rawJsonBody, Encoding.UTF8, Request.ContentType ?? "application/json");
                }
            }

            var response = await client.SendAsync(requestMessage);
            
            if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
            {
                Response.Cookies.Delete("jwt_token");
                return Unauthorized(new { message = "Token rejected by the server (Expired)." });
            }

            var result = await response.Content.ReadAsStringAsync();
            var contentType = response.Content.Headers.ContentType?.ToString() ?? "application/json";
            
            return Content(result, contentType);
        }
    }
}
using Microsoft.AspNetCore.Mvc;
using System.Text;
using System.Net.Http.Headers;
using Newtonsoft.Json;

namespace RFIDP2P3_Web.Controllers
{
    [Route("ApiProxy")]
    public class ApiProxyController : Controller
    {
        private readonly IConfiguration _config;

        public ApiProxyController(IConfiguration config)
        {
            _config = config;
        }

        [Route("Forward/{*targetPath}")]
        public async Task<IActionResult> Forward(string targetPath)
        {
            var token = Request.Cookies["jwt_token"];
            if (string.IsNullOrEmpty(token))
                return Unauthorized(new { message = "Session expired, please log in again." });

            string baseUrl = _config.GetValue<string>("Path:URL") ?? "";
            string fullUrl = $"{baseUrl.TrimEnd('/')}/{targetPath}{Request.QueryString}";

            using var client = new HttpClient();
            var method = new HttpMethod(Request.Method);

            using var requestMessage = await CreateRequestMessageAsync(method, fullUrl);
            requestMessage.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var response = await client.SendAsync(requestMessage);
            
            if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
            {
                var refreshToken = Request.Cookies["jwt_refresh_token"];
                if (!string.IsNullOrEmpty(refreshToken))
                {
                    var refreshPayload = new
                    {
                        AccessToken = token,
                        RefreshToken = refreshToken
                    };

                    var refreshContent = new StringContent(JsonConvert.SerializeObject(refreshPayload), Encoding.UTF8, "application/json");
                    var refreshResponse = await client.PostAsync($"{baseUrl.TrimEnd('/')}/Auth/Refresh", refreshContent);

                    if (refreshResponse.IsSuccessStatusCode)
                    {
                        var refreshResultStr = await refreshResponse.Content.ReadAsStringAsync();
                        dynamic refreshResult = JsonConvert.DeserializeObject(refreshResultStr);
                        string newToken = refreshResult.token;
                        string newRefreshToken = refreshResult.refreshToken;

                        Response.Cookies.Append("jwt_token", newToken, new CookieOptions
                        {
                            HttpOnly = true,
                            Secure = Request.IsHttps,
                            SameSite = SameSiteMode.Strict
                        });

                        Response.Cookies.Append("jwt_refresh_token", newRefreshToken, new CookieOptions
                        {
                            HttpOnly = true,
                            Secure = Request.IsHttps,
                            SameSite = SameSiteMode.Strict,
                            Expires = DateTimeOffset.UtcNow.AddDays(_config.GetValue<int>("CookieSettings:RefreshTokenExpireDays", 7))
                        });

                        using var retryMessage = await CreateRequestMessageAsync(method, fullUrl);
                        retryMessage.Headers.Authorization = new AuthenticationHeaderValue("Bearer", newToken);
                        response = await client.SendAsync(retryMessage);
                    }
                    else
                    {
                        Response.Cookies.Delete("jwt_token");
                        Response.Cookies.Delete("jwt_refresh_token");
                        return Unauthorized(new { message = "Session expired completely. Please log in again." });
                    }
                }
                else
                {
                    Response.Cookies.Delete("jwt_token");
                    return Unauthorized(new { message = "Token rejected by the server (Expired)." });
                }
            }

            var result = await response.Content.ReadAsStringAsync();
            var contentType = response.Content.Headers.ContentType?.ToString() ?? "application/json";
            
            if (contentType.Contains("application/vnd.openxmlformats-officedocument") || 
                contentType.Contains("application/octet-stream"))
            {
                var fileStream = await response.Content.ReadAsStreamAsync();
                var contentDisposition = response.Content.Headers.ContentDisposition;
                string downloadName = contentDisposition?.FileNameStar ?? contentDisposition?.FileName?.Trim('"') ?? "download.xlsx";
    
                string pureMediaType = response.Content.Headers.ContentType?.MediaType ?? "application/octet-stream";
    
                return File(fileStream, pureMediaType, downloadName);
            }
            
            return new ContentResult
            {
                Content = result,
                ContentType = contentType,
                StatusCode = (int)response.StatusCode
            };
        }

        private async Task<HttpRequestMessage> CreateRequestMessageAsync(HttpMethod method, string fullUrl)
        {
            var requestMessage = new HttpRequestMessage(method, fullUrl);

            if (method != HttpMethod.Get && method != HttpMethod.Delete && method != HttpMethod.Head)
            {
                if (Request.HasFormContentType)
                {
                    var multipartContent = new MultipartFormDataContent();
                    foreach (var field in Request.Form)
                    {
                        multipartContent.Add(new StringContent(field.Value!), field.Key);
                    }
                    foreach (var file in Request.Form.Files)
                    {
                        var stream = file.OpenReadStream();
                        var fileContent = new StreamContent(stream);
                        fileContent.Headers.ContentType = new MediaTypeHeaderValue(file.ContentType);
                        multipartContent.Add(fileContent, file.Name, file.FileName);
                    }
                    requestMessage.Content = multipartContent;
                }
                else
                {
                    Request.EnableBuffering();
                    Request.Body.Position = 0;
                    using var reader = new StreamReader(Request.Body, Encoding.UTF8, leaveOpen: true);
                    var body = await reader.ReadToEndAsync();
                    Request.Body.Position = 0;
                    requestMessage.Content = new StringContent(body, Encoding.UTF8, Request.ContentType ?? "application/json");
                }
            }
            return requestMessage;
        }
    }
}
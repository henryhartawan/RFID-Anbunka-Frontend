using Microsoft.AspNetCore.Mvc;
using System.Text;
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
            string fullUrl = $"{baseUrl.TrimEnd('/')}/{targetPath}{Request.QueryString}";

            using var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            var method = new HttpMethod(Request.Method);
            using var requestMessage = new HttpRequestMessage(method, fullUrl);

            if (method != HttpMethod.Get &&
                method != HttpMethod.Delete &&
                method != HttpMethod.Head)
            {
                if (Request.HasFormContentType)
                {
                    var form = await Request.ReadFormAsync();

                    var multipartContent = new MultipartFormDataContent();

                    foreach (var field in form)
                    {
                        multipartContent.Add(
                            new StringContent(field.Value!),
                            field.Key);
                    }

                    foreach (var file in form.Files)
                    {
                        var stream = file.OpenReadStream();

                        var fileContent = new StreamContent(stream);

                        fileContent.Headers.ContentType =
                            new MediaTypeHeaderValue(file.ContentType);

                        multipartContent.Add(
                            fileContent,
                            file.Name,
                            file.FileName);
                    }

                    requestMessage.Content = multipartContent;
                }
                else
                {
                    Request.EnableBuffering();

                    Request.Body.Position = 0;

                    using var reader = new StreamReader(
                        Request.Body,
                        Encoding.UTF8,
                        leaveOpen: true);

                    var body = await reader.ReadToEndAsync();

                    Request.Body.Position = 0;

                    requestMessage.Content = new StringContent(
                        body,
                        Encoding.UTF8,
                        Request.ContentType ?? "application/json");
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
    }
}
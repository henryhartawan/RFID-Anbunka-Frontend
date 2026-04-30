using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace RFIDP2P3_Web.Filters
{
    public class SessionAuthorizeAttribute : Attribute, IAuthorizationFilter
    {
        private readonly string _permission;

        public SessionAuthorizeAttribute(string permission)
        {
            _permission = permission;
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var session = context.HttpContext.Session;

            // cek login
            if (session.GetString("PIC_ID") == null)
            {
                context.Result = new RedirectToActionResult("Index", "Login", null);
                return;
            }

            // cek permission (tetap pakai "True")
            if (!string.IsNullOrEmpty(_permission))
            {
                var value = session.GetString(_permission);

                if (!string.Equals(value, "True", StringComparison.OrdinalIgnoreCase))
                {
                    context.HttpContext.Session.SetString("IsAccessDenied", "1");
                    context.Result = new StatusCodeResult(403);
                    return;
                }
            }
        }
    }
}

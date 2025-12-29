using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Web;
using System.Web.UI;

namespace BookStoreApp.Helpers
{
    public class BasePage : Page
    {
        protected string LoggedInEmail { get; private set; }

        protected override void OnInit(EventArgs e)
        {
            // Read JWT and set LoggedInEmail at the earliest point in the lifecycle
            var jwtCookie = Request.Cookies["JWT"];

            if (jwtCookie == null || string.IsNullOrWhiteSpace(jwtCookie.Value)     )
            {
                SafeRedirect();
                return;
            }

            try
            {
                var handler = new JwtSecurityTokenHandler();
                var token = handler.ReadJwtToken(jwtCookie.Value);

                var emailClaim = token.Claims.FirstOrDefault(c => c.Type == "email");

                if (emailClaim == null || string.IsNullOrWhiteSpace(emailClaim.Value))
                {
                    SafeRedirect();
                    return;
                }

                LoggedInEmail = emailClaim.Value;
                // Cache for downstream access in the same request (optional convenience)
                Context.Items["LoggedInEmail"] = LoggedInEmail;
            }
            catch
            {
                SafeRedirect();
                return;
            }

            base.OnInit(e);
        }

        private void SafeRedirect()
        {
            Response.Redirect("~/Account/Login.aspx", false);
            Context.ApplicationInstance.CompleteRequest();
        }
    }

}

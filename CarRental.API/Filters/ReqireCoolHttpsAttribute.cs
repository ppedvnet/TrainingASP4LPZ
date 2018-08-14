using System;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace CarRental.API.Filters
{
    public class ReqireCoolHttpsAttribute : AuthorizationFilterAttribute
    {
        public override void OnAuthorization(HttpActionContext ctx)
        {
            if (ctx.Request.RequestUri.Scheme != Uri.UriSchemeHttps)
            {
                ctx.Response = new System.Net.Http.HttpResponseMessage(System.Net.HttpStatusCode.Forbidden)
                {
                    ReasonPhrase = "HTTPS Erforderlich..."
                };
            }
            else
            {
                base.OnAuthorization(ctx);
            }
        }
    }
}
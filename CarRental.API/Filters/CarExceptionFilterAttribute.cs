using System;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Filters;

namespace CarRental.API.Filters
{
    public class CarExceptionFilterAttribute : ExceptionFilterAttribute
    {
        public override void OnException(HttpActionExecutedContext ctx)
        {
            if (ctx.Exception.GetType() == typeof(ArgumentException))
            { 
                //...
            }

            var msg = new HttpResponseMessage(System.Net.HttpStatusCode.InternalServerError)
            {
                Content = new StringContent(ctx.Exception.Message)
            };
            throw new HttpResponseException(msg);
        }
    }
}
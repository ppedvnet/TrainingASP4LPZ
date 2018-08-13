using System.Diagnostics;
using System.Web.Mvc;
using System.Web.Routing;

namespace CarRental.Filters
{
    public class LogAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            Log("OnActionExecuted", filterContext.RouteData);
        }

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            Log("OnActionExecuting", filterContext.RouteData);
        }

        private void Log(string methodName, RouteData routeData)
        {
            var ctrl = routeData.Values["controller"];

            var msg = $"Hallo Leipzig von {methodName} und {ctrl}";

            Debug.WriteLine(msg);
        }
    }
}
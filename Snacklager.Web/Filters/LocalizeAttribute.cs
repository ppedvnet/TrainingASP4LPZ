using System.Globalization;
using System.Threading;
using System.Web.Mvc;


namespace Snacklager.Web.Filters
{
    public class LocalizeAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            string culture = "de";


            if (filterContext.HttpContext.Request.Cookies["culture"] != null)
            {
                culture = filterContext.HttpContext.Request.Cookies["culture"].Value;
            }
            else if (filterContext.HttpContext.Request.UserLanguages.Length > 0)
            {
                culture = filterContext.HttpContext.Request.UserLanguages[0];
            }

            Thread.CurrentThread.CurrentCulture = new CultureInfo(culture);
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(culture);
        }
    }
}
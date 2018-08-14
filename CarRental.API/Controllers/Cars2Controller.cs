using System.Threading.Tasks;
using System.Web.Http;
using CarRental.API.Filters;

namespace CarRental.API.Controllers
{
    [RoutePrefix("api/v2/cars")]
    [Authorize]
    [ReqireCoolHttpsAttribute]
    public class Cars2Controller : ApiController
    {
        [Route("")]
        public async Task<IHttpActionResult> GetAllCars()
        {
            //try
            //{
                //throw new Exception("Computer says no...");

                return Ok("Cars 2 Controller, sie sind eingeloggt...");

            //}
            //catch (Exception ex)
            //{
            //    return new StatusCodeResult(HttpStatusCode.InternalServerError, this);
            //}
        }
    }
}

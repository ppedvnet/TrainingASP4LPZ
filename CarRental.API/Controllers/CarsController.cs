using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using CarRental.API.Models;

namespace CarRental.API.Controllers
{
    [RoutePrefix("api/v1/cars")]
    //[EnableCors(origins: "*", headers: "*", methods: "*")]
    public class CarsController : ApiController
    {
        private CarRentalAPIContext db = new CarRentalAPIContext();

        /// <summary>
        /// GET: api/Cars super cool description
        /// </summary>
        /// <returns></returns>
        [Route("")]
        public async Task<IHttpActionResult> GetCars()
        {
            return Ok(await db.Cars.ToListAsync());
            //return new StatusCodeResult(HttpStatusCode.OK, this);
        }

        // GET: api/Cars/5
        [ResponseType(typeof(Car))]
        [Route("{id}", Name="GetCarById")]
        public async Task<IHttpActionResult> GetCar(int id)
        {
            Car car = await db.Cars.FindAsync(id);
            if (car == null)
            {
                return NotFound();
            }

            return Ok(car);
        }

        // PUT: api/Cars/5
        [ResponseType(typeof(void))]
        [Route("{id}")]
        public async Task<IHttpActionResult> PutCar(int id, Car car)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != car.Id)
            {
                return BadRequest();
            }

            db.Entry(car).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CarExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Cars
        [ResponseType(typeof(Car))]
        [Route("")]
        public async Task<IHttpActionResult> PostCar(Car car)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Cars.Add(car);
            await db.SaveChangesAsync();

            return CreatedAtRoute("GetCarById", new { id = car.Id }, car);
        }

        // DELETE: api/Cars/5
        [ResponseType(typeof(Car))]
        [Route("{id}")]
        public async Task<IHttpActionResult> DeleteCar(int id)
        {
            Car car = await db.Cars.FindAsync(id);
            if (car == null)
            {
                return NotFound();
            }

            db.Cars.Remove(car);
            await db.SaveChangesAsync();

            return Ok(car);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CarExists(int id)
        {
            return db.Cars.Count(e => e.Id == id) > 0;
        }
    }
}
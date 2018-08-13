using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using CarRental.Filters;
using CarRental.Models;

namespace CarRental.Controllers
{
    public class CarsController : Controller
    {
        [Log]
        //[HandleError(View = "Error", ExceptionType = typeof(ArgumentNullException))]
        //[HandleError(View = "Error404", ExceptionType= typeof(FileNotFoundException))]
        public ActionResult Index()
        {

            Trace.Write("Exception Handling...");

            //try
            //{
            //    throw new ArgumentNullException("Computer says no!");
            //}
            //catch (ArgumentNullException ex)
            //{
            //    ViewBag.ErrorMessage = ex.Message;
            //    throw;
            //}
            //catch (Exception ex)
            //{
            //    ViewBag.ErrorMessage = ex.Message;
            //}

            #region VM
            var car = new Car
            {
                Id = 1,
                Name = "Delorian",
                CarProducer = "DMC",
                Consumption = 10.23,
                YearOfConstruction = new DateTime(1985,1,1),
                CarType = CarType.Van
            };
            var car2 = new Car
            {
                Id = 2,
                Name = "Mustang",
                CarProducer = "Ford",
                Consumption = 33.56,
                YearOfConstruction = new DateTime(1978,1,1),
                CarType = CarType.Limosine
            };
            var cars = new List<Car>();
            cars.Add(car);
            cars.Add(car2);

            List<CarVm> carsVm = Mapper.Map<List<CarVm>>(cars);

            var xyz = HttpContext.Application["GlobalVar"];
            #endregion

            return View(carsVm);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CarVm carVm)
        {
            if (!ModelState.IsValid)
            {
                return View(carVm);
            }

            // mapping carVm => car
            // Daten auf DB speichern

            return View();
        }

        public ActionResult RazorDemo()
        {
            // ViewBag, ViewData, ViewModel
            var c = new CarVm { Name = "Golf" };

            ViewBag.Auto = c;
            ViewData["Auto"] = c;

            // Cookies
            var keks = new HttpCookie("keks");
            keks.Value = "Hallo Leipzig";
            keks.Expires = DateTime.Now.AddHours(1);

            Response.Cookies.Add(keks);
            //Response.Cookies["keks"].Expires = DateTime.Now.AddDays(-1);

            string xyz;
            if (Request.Cookies["keks"] != null)
                xyz = Request.Cookies["keks"].Value;

            Session["Autos"] = c;
            var cool = Session["Autos"] as CarVm;

            HttpContext.Application["GlobalVar"] = 123;

            return View();
        }

        public ActionResult GetMoreCars()
        {
            var cars = new List<CarVm>
            {
                new CarVm
                {
                    Name = "Golf",
                    CarType = CarType.Kompakt,
                    Producer = "VW"
                },
                new CarVm
                {
                    Name = "Manta",
                    CarType = CarType.Van,
                    Producer = "Opel"
                }
            };

            return PartialView("_CarsTableResult", cars);
        }
    }
}
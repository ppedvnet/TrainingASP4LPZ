using System;
using System.Web.Mvc;
using System.Collections.Generic;
using AutoMapper;
using Snacklager.Logic;
using Snacklager.Logic.Contracts;
using Snacklager.Web.Models;
using Snacklager.Data;
using System.Web;
using Snacklager.Web.Filters;

namespace Snacklager.Web.Controllers
{
    public class SnackController : Controller
    {
        //ISnackRepository _snackRepo = new SnackRepository();
        private readonly ISnackRepository _snackRepo;

        public SnackController(ISnackRepository snackRepository)
        {
            _snackRepo = snackRepository;
        }

        // Language Switch
        public ActionResult SetCulture(string culture)
        {
            var langKeks = new HttpCookie("culture", culture);
            langKeks.Expires = DateTime.Now.AddDays(1);

            Response.Cookies.Add(langKeks);

            return RedirectToAction("Create");
        }

        // GET: Snack
        public ActionResult Index()
        {
            var snacksDb = _snackRepo.GetAll();

            var snacksVm = Mapper.Map<List<SnackDisplayVm>>(snacksDb);

            return View(snacksVm);
        }

        // GET: Snack/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Snack/Create
        [Localize]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Snack/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(SnackCreateVm snackVm)
        {
            if (!ModelState.IsValid)
            {
                return View(snackVm);
            }

            var snackDb = Mapper.Map<Snack>(snackVm);
            _snackRepo.Insert(snackDb);
            _snackRepo.SaveAll();

            return RedirectToAction("Index");
        }

        // GET: Snack/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Snack/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Snack/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Snack/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}

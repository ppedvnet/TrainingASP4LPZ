using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DBFirstDemo;
using PagedList;

namespace DBFirstDemo.Controllers
{
    public class CustomersController : Controller
    {
        private NorthwindEntities db = new NorthwindEntities();

        // GET: Customers
        public async Task<ActionResult> Index(string sortOrder, bool asc = true, int? page = null)
        {
            int pageSize = 5;
            int pageIndex = page.HasValue ? Convert.ToInt32(page) : 1;

            sortOrder = String.IsNullOrWhiteSpace(sortOrder) ? "CompanyName" : sortOrder;
            ViewBag.CurrentSort = sortOrder;
            ViewBag.Asc = asc;

            var query = db.Customers;

            IPagedList<Customer> customers = null;

            await Task.Run(() =>
            {
                switch (sortOrder)
                {
                    case "CustomerID":
                        customers = asc ? query.OrderBy(m => m.CustomerID).ToPagedList(pageIndex, pageSize) : query.OrderByDescending(m => m.CustomerID).ToPagedList(pageIndex, pageSize);
                        break;
                    case "ContactName":
                        customers = asc ? query.OrderBy(m => m.ContactName).ToPagedList(pageIndex, pageSize) : query.OrderByDescending(m => m.ContactName).ToPagedList(pageIndex, pageSize);
                        break;
                    default:
                        customers = asc ? query.OrderBy(m => m.CompanyName).ToPagedList(pageIndex, pageSize) : query.OrderByDescending(m => m.CompanyName).ToPagedList(pageIndex, pageSize);
                        break;
                }

            });

            return View(customers);

        }

        // GET: Customers/Details/5
        public async Task<ActionResult> Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = await db.Customers.FindAsync(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        // GET: Customers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Customers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "CustomerID,CompanyName,ContactName,ContactTitle,Address,City,Region,PostalCode,Country,Phone,Fax")] Customer customer)
        {
            if (ModelState.IsValid)
            {
                db.Customers.Add(customer);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(customer);
        }

        // GET: Customers/Edit/5
        public async Task<ActionResult> Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = await db.Customers.FindAsync(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        // POST: Customers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "CustomerID,CompanyName,ContactName,ContactTitle,Address,City,Region,PostalCode,Country,Phone,Fax")] Customer customer)
        {
            if (ModelState.IsValid)
            {
                db.Entry(customer).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(customer);
        }

        // GET: Customers/Delete/5
        public async Task<ActionResult> Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = await db.Customers.FindAsync(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        // POST: Customers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(string id)
        {
            Customer customer = await db.Customers.FindAsync(id);
            db.Customers.Remove(customer);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        //~CustomersController()
        //{
        //    Dispose(true);
        //    //db.Dispose();
        //}
    }
}

using MvcProject_Lema.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PagedList;

namespace MvcProject_Lema.Controllers
{
    public class CustomerController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: Patient
        //public ActionResult Index()
        //{
        //    return View(db.Patients.ToList());
        //}

        public ActionResult Index(string sortOrder, string searchString, string currentFilter, int? page)
        {
            ViewBag.CurrentSort = sortOrder;
            ViewBag.NameSortParam = string.IsNullOrEmpty(sortOrder) ? "CustomerName_desc" : "";

            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewBag.CurrentFilter = searchString;
            var cus = from t in db.Customers
                           select t;
            if (!string.IsNullOrEmpty(searchString))
            {
                cus = cus.Where(cu => cu.CustomerName.ToUpper().Contains(searchString.ToUpper()));
            }
            switch (sortOrder)
            {
                case "CustomerName_desc":
                    cus = cus.OrderByDescending(cu => cu.CustomerName);
                    break;
                default:
                    cus = cus.OrderBy(cu => cu.CustomerName);
                    break;
            }
            int pageSize = 2;
            int pageNumber = (page ?? 1);
            return View(cus.ToPagedList(pageNumber, pageSize));
        }

        //Get by ID
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customers = db.Customers.Find(id);
            if (customers == null)
            {
                return HttpNotFound();
            }
            return View(customers);
        }

        // GET Create
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CustomerId,CustomerName,Email,CarNumber,PhoneNumber")] Customer customers)
        {
            if (ModelState.IsValid)
            {
                db.Customers.Add(customers);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(customers);
        }

        // GET Edit by id
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customers = db.Customers.Find(id);
            if (customers == null)
            {
                return HttpNotFound();
            }
            return View(customers);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CustomerId,CustomerName,Email,CarNumber,PhoneNumber")] Customer customers)
        {
            if (ModelState.IsValid)
            {
                db.Customers.Add(customers);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(customers);
        }

        // GET Delete by id
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customers = db.Customers.Find(id);
            if (customers == null)
            {
                return HttpNotFound();
            }
            return View(customers);
        }

        // POST Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Customer customers = db.Customers.Find(id);
            db.Customers.Remove(customers);
            db.SaveChanges();
            return RedirectToAction("Index");
        }


        public ActionResult Sorting(string sortOrder)
        {
            ViewBag.NameSortParam = string.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            var cus = db.Customers.AsQueryable();

            /* IQueryable<Patients> patients = db.Patients; */// Get the patients from the database

            switch (sortOrder)
            {
                case "name_desc":
                    cus = cus.OrderByDescending(p => p.CustomerName);
                    break;
                default:
                    cus = cus.OrderBy(p => p.CustomerName);
                    break;
            }

            return View(cus.ToList());
            //return View(patients.ToPagedList(page??1,3));
        }



    }
}
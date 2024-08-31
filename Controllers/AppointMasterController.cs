using MvcProject_Lema.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace MvcProject_Lema.Controllers
{
    public class AppointMasterController : Controller
    {
        // GET: AppointMaster
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Trainee
        public ActionResult Index()
        {
            return View(db.AppointMasters.ToList());
        }

        // GET: Trainee/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AppointMaster appointMaster = db.AppointMasters.Find(id);
            if (appointMaster == null)
            {
                return HttpNotFound();
            }
            return View(appointMaster);
        }
        public JsonResult AppointDetails(int id)
        {
            var appointDetail = db.AppointDetails.Where(o => o.AppointMasterId == id).AsEnumerable().Select(o => new { appointMasterId = o.AppointMasterId, serviceId = o.ServiceId, quantity = o.Quantity.ToString("dd-MM-yyyy"), price = o.Price });
            return Json(appointDetail, JsonRequestBehavior.AllowGet);
        }

        // GET: Trainee/Create
        public ActionResult Create()
        {
            return View();
        }
        // POST: Trainee/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "AppointMasterId,AppointDate,CustomerName,Image")] AppointMaster appointMaster)
        {
            if (ModelState.IsValid)
            {
                db.AppointMasters.Add(appointMaster);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(appointMaster);
        }
        // GET: Trainee/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AppointMaster appointMaster = db.AppointMasters.Find(id);
            if (appointMaster == null)
            {
                return HttpNotFound();
            }
            return View(appointMaster);
        }

        // POST: Trainee/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AppointMasterId,AppointDate,CustomerName,Image")] AppointMaster appointMaster)
        {
            if (ModelState.IsValid)
            {
                db.Entry(appointMaster).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(appointMaster);
        }

        // GET: Trainee/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AppointMaster appointMaster = db.AppointMasters.Find(id);
            if (appointMaster == null)
            {
                return HttpNotFound();
            }
            return View(appointMaster);
        }

        // POST: Trainee/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AppointMaster appointMaster = db.AppointMasters.Find(id);
            db.AppointMasters.Remove(appointMaster);
            db.SaveChanges();
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


    }
}
using MvcProject_Lema.DAL;
using MvcProject_Lema.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProject_Lema.Controllers
{
    public class AppointController : Controller
    {
        public AppointDetailsContest db = new AppointDetailsContest();
        // GET: Appoint
        public ActionResult Index()
        {
            return View();
        }
        public JsonResult getServiceCategories()
        {
            List<Category> categories = new List<Category>();
            categories = db.Categories.OrderBy(c => c.categoryName).ToList();
            return new JsonResult { Data = categories, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }
        public JsonResult getServices(int categoryId)
        {
            List<Service> services = new List<Service>();
            services = db.Services.Where(p => p.CategoryId.Equals(categoryId)).OrderBy(po => po.ServiceName).ToList();
            return new JsonResult { Data = services, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }

        public JsonResult Save(AppointMaster order, HttpPostedFileBase file)
        {
            bool status = false;
            if (file != null)
            {
                string folderPath = Server.MapPath("~/Images/");
                string fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                string filePath = Path.Combine(folderPath, fileName);
                file.SaveAs(filePath);
                order.Image = fileName;
            }
            var isvalidmodel = TryUpdateModel(order);
            if (isvalidmodel)
            {
                db.AppointMasters.Add(order);
                db.SaveChanges();
                status = true;
            }
            return new JsonResult { Data = new { status = status } };
        }
    }
}


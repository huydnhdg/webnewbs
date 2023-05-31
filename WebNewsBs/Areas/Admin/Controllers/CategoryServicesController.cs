
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebNewsBs.Models;

namespace WebNewsBs.Areas.Admin.Controllers
{
    [Authorize]
    public class CategoryServicesController : Controller
    {
        Entities db = new Entities();
        // GET: Admin/CategoryNews
        public ActionResult Index()
        {
            var model = db.Category_Service.OrderByDescending(a => a.create_date);
            return View(model);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "")] Category_Service category)
        {
            if (ModelState.IsValid)
            {
                category.create_date = DateTime.Now;
                db.Category_Service.Add(category);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(category);

        }
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Category_Service category = db.Category_Service.Find(id);
            if (category == null)
            {
                return HttpNotFound();
            }
            return View(category);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "")] Category_Service category)
        {
            if (ModelState.IsValid)
            {
                category.edit_date = DateTime.Now;
                db.Entry(category).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(category);

        }
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Category_Service category = db.Category_Service.Find(id);
            if (category == null)
            {
                return HttpNotFound();
            }
            return View(category);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            Category_Service category = db.Category_Service.Find(id);
            db.Category_Service.Remove(category);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}
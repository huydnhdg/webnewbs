using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using WebNewsBs.Models;

namespace WebNewsBs.Areas.Admin.Controllers
{
    [Authorize]
    public class ServicesController : Controller
    {
        Entities db = new Entities();
        public ActionResult Index()
        {
            var model = db.Services.OrderByDescending(a => a.create_date);
            return View(model);
        }
        public ActionResult Create()
        {
            var droplist = new List<Category_Service>();
            droplist.Add(new Category_Service()
            {

                type_service = "Select Category_Service",
            });
            droplist.AddRange(db.Category_Service.OrderBy(a => a.type_service).ToList());
            ViewBag.Category_Service = droplist;
            return View();
        }
        [HttpPost, ValidateInput(false)]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "")] Service service)
        {
            if (ModelState.IsValid)
            {
                service.create_date = DateTime.Now;
                db.Services.Add(service);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(service);

        }
        public ActionResult Edit(long? id)
        {

            var droplist = new List<Category_Service>();
            droplist.Add(new Category_Service()
            {

                type_service = "Select Category_Service",
            });
            droplist.AddRange(db.Category_Service.OrderBy(a => a.type_service).ToList());
            ViewBag.Category_Service = droplist;
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Service service = db.Services.Find(id);
            if (service == null)
            {
                return HttpNotFound();
            }
            return View(service);
        }
        [HttpPost, ValidateInput(false)]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "")] Service service)
        {
            if (ModelState.IsValid)
            {
                service.edit_date = DateTime.Now;
                db.Entry(service).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(service);

        }
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Service service = db.Services.Find(id);
            if (service == null)
            {
                return HttpNotFound();
            }
            return View(service);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            Service service = db.Services.Find(id);
            db.Services.Remove(service);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}
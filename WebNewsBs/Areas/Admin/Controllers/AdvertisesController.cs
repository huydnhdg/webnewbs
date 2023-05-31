using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebNewsBs.Models;

namespace WebNewsBs.Areas.Admin.Controllers
{
    public class AdvertisesController : Controller
    {
        private Entities db = new Entities();

        // GET: Admin/Advertises
        public ActionResult Index()
        {
            return View(db.Advertises.ToList());
        }

        // GET: Admin/Advertises/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Advertise advertise = db.Advertises.Find(id);
            if (advertise == null)
            {
                return HttpNotFound();
            }
            return View(advertise);
        }

        // GET: Admin/Advertises/Create
        public ActionResult Create()
        {
            var droplist = new List<Category_Post>();
            droplist.Add(new Category_Post()
            {

                type_post = "Select Category_Post",
            });
            droplist.AddRange(db.Category_Post.OrderBy(a => a.type_post).ToList());
            ViewBag.Category_Post = droplist;
            return View();
        }

        // POST: Admin/Advertises/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "")] Advertise advertise)
        {
            if (ModelState.IsValid)
            {
                db.Advertises.Add(advertise);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(advertise);
        }

        // GET: Admin/Advertises/Edit/5
        public ActionResult Edit(int? id)
        {
            var droplist = new List<Category_Post>();
            droplist.Add(new Category_Post()
            {

                type_post = "Select Category_Post",
            });
            droplist.AddRange(db.Category_Post.OrderBy(a => a.type_post).ToList());
            ViewBag.Category_Post = droplist;
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Advertise advertise = db.Advertises.Find(id);
            if (advertise == null)
            {
                return HttpNotFound();
            }
            return View(advertise);
        }

        // POST: Admin/Advertises/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "")] Advertise advertise)
        {
            if (ModelState.IsValid)
            {
                db.Entry(advertise).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(advertise);
        }

        // GET: Admin/Advertises/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Advertise advertise = db.Advertises.Find(id);
            if (advertise == null)
            {
                return HttpNotFound();
            }
            return View(advertise);
        }

        // POST: Admin/Advertises/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Advertise advertise = db.Advertises.Find(id);
            db.Advertises.Remove(advertise);
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

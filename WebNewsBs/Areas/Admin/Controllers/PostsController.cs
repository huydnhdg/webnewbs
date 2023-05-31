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
    public class PostsController : Controller
    {
        Entities db = new Entities();
        public ActionResult Index()
        {
            var model = db.Posts.OrderByDescending(a => a.create_date);
            return View(model);
        }

        public ActionResult Create()
        {
            var droplist = new List<Category_Post>();
            droplist.Add(new Category_Post()
            {

                type_post = "Select Category_Post",
            }) ;
            droplist.AddRange(db.Category_Post.OrderBy(a => a.type_post).ToList());
            ViewBag.Category_Post = droplist;
            return View();
        }
        [HttpPost, ValidateInput(false)]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "")] Post posts)
        {
            if (ModelState.IsValid)
            {
                posts.create_date = DateTime.Now;
                db.Posts.Add(posts);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(posts);

        }

        public ActionResult Edit(long? id)
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
            Post news = db.Posts.Find(id);
            if (news == null)
            {
                return HttpNotFound();
            }
            return View(news);
        }
        [HttpPost, ValidateInput(false)]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "")] Post news)
        {
            if (ModelState.IsValid)
            {
                news.edit_date = DateTime.Now;
                db.Entry(news).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(news);

        }

        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Post news = db.Posts.Find(id);
            if (news == null)
            {
                return HttpNotFound();
            }
            return View(news);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            Post news = db.Posts.Find(id);
            db.Posts.Remove(news);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
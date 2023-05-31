using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using WebNewsBs.Models;

namespace WebNewsBs.Areas.Admin.Controllers
{
    [Authorize]
    public class ConfigController : Controller
    {
        Entities db = new Entities();
        public ActionResult Index()
        {
            var model = db.Configs.OrderByDescending(a => a.id);
            return View(model);
        }
        public ActionResult Edit(long? id = 1)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Config config = db.Configs.Find(id);
            if (config == null)
            {
                return HttpNotFound();
            }
            return View(config);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "")] Config config)
        {
            if (ModelState.IsValid)
            {
                db.Entry(config).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(config);

        }
    }
}
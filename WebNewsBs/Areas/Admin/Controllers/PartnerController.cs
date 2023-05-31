using System.Data.Entity;
using System.IO;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebNewsBs.Models;

namespace WebNewsBs.Areas.Admin.Controllers
{
    [Authorize]
    public class PartnerController : Controller
    {
        Entities db = new Entities();
        public ActionResult Index()
        {
            var model = db.Partners;
            return View(model);
        }

        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "")] Partner parter)
        {
            if (ModelState.IsValid)
            {
                db.Partners.Add(parter);
                db.SaveChanges();   
                return RedirectToAction("Index");
            }
            return View(parter);

        }

        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Partner partner = db.Partners.Find(id);
            if (partner == null)
            {
                return HttpNotFound();
            }
            return View(partner);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "")] Partner partner)
        {
            if (ModelState.IsValid)
            { 
                db.Entry(partner).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(partner);

        }

        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Partner partner = db.Partners.Find(id);
            if (partner == null)
            {
                return HttpNotFound();
            }
            return View(partner);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            Partner partner = db.Partners.Find(id);
            db.Partners.Remove(partner);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        //[HttpPost]
        ///// <summary>
        ///// This method wil be call from client via Ajax jQuery.
        ///// </summary>
        ///// <param name="file"></param>
        ///// <returns></returns>
        //public JsonResult SaveFile(HttpPostedFileBase file)
        //{
        //    string returnImagePath = string.Empty;
        //    if (file.ContentLength > 0)
        //    {
        //        string fileName, fileExtension, imaageSavePath;
        //        fileName = Path.GetFileNameWithoutExtension(file.FileName);
        //        fileExtension = Path.GetExtension(file.FileName);
        //        imaageSavePath = Server.MapPath("/uploadedImages/") + fileName + fileExtension;
        //        //Save file
        //        file.SaveAs(imaageSavePath);
        //        //Path to return
        //        returnImagePath = "/uploadedImages/" + fileName + fileExtension;
        //    }
        //    return Json(returnImagePath, JsonRequestBehavior.AllowGet);
        //}
    }
}
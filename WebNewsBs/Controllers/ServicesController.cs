using PagedList;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using WebNewsBs.Models;

namespace WebNewsBs.Controllers
{
    [RoutePrefix("dich-vu")]
    public class ServicesController : Controller
    {


        Entities db = new Entities();
        [Route]
        // GET: Services
        public ActionResult Index()
        {
            var model = db.Services.OrderByDescending(a => a.service_id).FirstOrDefault();

            return View(model);
        }
        [HttpGet]
        [Route("{alt}")]
        public ActionResult Details(string alt)
        {

            if (alt == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Service model = db.Services.Where(a => a.alt == alt).SingleOrDefault();
            var listOld = db.Services.Where(a=>a.service_id != model.service_id).Take(10).ToList();
            ViewBag.listOld = listOld;
            if (model == null)
            {
                return HttpNotFound();
            }
            return View(model);
        }

    }
}
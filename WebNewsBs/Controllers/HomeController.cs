using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebNewsBs.Models;

namespace WebNewsBs.Controllers
{


    public class HomeController : Controller
    {
        Entities db = new Entities();
        [Route]
        public ActionResult Index()
        {
            var model = db.Partners.OrderByDescending(x => x.partner_id);

            var listOld = db.Posts.OrderByDescending(a=>a.post_id).Take(6).ToList();
            ViewBag.listOld = listOld;
            return View(model);
        }
        [Route("gioi-thieu")]
        public ActionResult About()
        {

            return View();
        }
        [Route("lien-he")]
        public ActionResult Contact()
        {

            return View();
        }
        public ActionResult Team()
        {

            return View();
        }

    }
}
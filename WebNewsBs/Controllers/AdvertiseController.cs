using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Web;
using System.Web.Mvc;
using WebNewsBs.Models;

namespace WebNewsBs.Controllers
{
   
    public class AdvertiseController : Controller
    {
        Entities db = new Entities();
        // GET: Advertise
        [Route("doi-tac")]
        public ActionResult Index()
        {
            var model = db.Advertises.OrderByDescending(x => x.id);
            return View(model);
        }
        [Route("tin-doi-tac")]
        public ActionResult Tindoitac(int? page )
        {


        
            if (page == null) page = 1;



            int pagesize = 6;

            int pagenumber = (page ?? 1);
          
            var newslist = new List<Post>();
            newslist = db.Posts.Where(a=>a.cate_post_id == 13).OrderByDescending(a => a.create_date).Take(6).ToList();

            return View(newslist.ToPagedList(pagenumber, pagesize));

        }
    }
}
using PagedList;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Services.Description;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebNewsBs.Models;

namespace WebNewsBs.Controllers
{
    [RoutePrefix("tin-tuc")]
    public class BlogsController : Controller
    {

        Entities db = new Entities();
        // GET: Blogs
        [Route]
        public ActionResult Index(int? page , string SearchString , string currentFilter)
        {
          

            if (page == null) page = 1;



            int pagesize = 4;

            int pagenumber = (page ?? 1);
            var newslist = new List<Post>();
            if(SearchString!=null)
            {
                page = 1;
            }    
            else
            {
                SearchString = currentFilter;

            }   
            if(!string.IsNullOrEmpty(SearchString))
            {
                newslist = db.Posts.Where(a => a.title.Contains(SearchString)).OrderByDescending(a => a.create_date).Take(4).ToList();
            }    
            else
            {
                newslist = db.Posts.OrderByDescending(a => a.create_date).ToList();
            }    
            var listpost = db.Posts.OrderByDescending(a => a.createby);
            List<Post> newslist1 = listpost.Take(3).ToList();
            ViewBag.newslist = newslist1;
            var listcate = db.Category_Post.OrderByDescending(a => a.cate_post_id);
            List<Category_Post> newslist2 = listcate.ToList();
            ViewBag.listcate = newslist2;

            return View(newslist.ToPagedList(pagenumber, pagesize)) ;

        }
      
        [HttpGet]
        [Route("{alt}")]
        public ActionResult Detail(string alt)
        {

            if (alt == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var model = db.Posts.Where(a => a.alt == alt).SingleOrDefault();
            var listOld = db.Posts.Where(a => a.cate_post_id == model.cate_post_id && a.post_id != model.post_id).Take(6).ToList();
            ViewBag.listOld = listOld;
            if (model == null)
            {
                return HttpNotFound();
            }
            return View(model);
        }
    }
}
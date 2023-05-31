using System.Linq;
using System.Net;
using System.Web.Mvc;
using WebNewsBs.Models;

namespace WebNewsBs.Areas.Admin.Controllers
{
    [Authorize]
    public class CustomerController : Controller
    {
        Entities db = new Entities();
        // GET: Admin/Khachhang
        public ActionResult Index()
        {
            var model = db.Customers.OrderByDescending(a => a.last_name);
            return View(model);
        }
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer cus = db.Customers.Find(id);
            if (cus == null)
            {
                return HttpNotFound();
            }
            return View(cus);
        }
    }
}
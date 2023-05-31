using System;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Web;
using System.Web.Mail;
using System.Web.Mvc;
using WebNewsBs.Models;
using MailMessage = System.Net.Mail.MailMessage;

namespace WebNewsBs.Controllers
{

    public class CustomersController : Controller
    {
        private Entities db = new Entities();

         [Route("dang-ki-thanh-cong")]
        public ActionResult Index()
        {
            return View();
        }

 
        [HttpPost]
        public ActionResult Index(String first_name, String last_name, String address, String email, String phone,
            String company, String note)
        {
            var cus = new Customer()
            {
                first_name = first_name,
                last_name = last_name,
                address = address,
                email = email,
                phone = phone,
                company = company,
                note = note,
                create_date = DateTime.Now
            };
            
            db.Customers.Add(cus);
            db.SaveChanges();

          
              return RedirectToAction("Index");
        }

        //[HttpPost]
        //public JsonResult Popup(string last_name, string phone, string email, string company, string note)
        //{
        //    if (phone.Length != 0)
        //    {
        //        ContentMail content = new ContentMail();
        //        content.str = last_name;
        //        content.str1 = phone;
        //        content.str2 = email;
        //        content.str3 = company;
        //        content.str4 = note;
        //        SendMail(content);
        //        return Json(new
        //        {
        //            status = true
        //        });
        //    }
        //    else
        //    {
        //        return Json(new
        //        {
        //            status = false
        //        });
        //    }
        //}
        //[HttpPost]
        //public JsonResult Contact(string last_name, string phone, string email, string company, string note)
        //{
        //    if (phone.Length != 0)
        //    {
        //        ContentMail content = new ContentMail();
        //        content.str = last_name;
        //        content.str1 = phone;
        //        content.str2 = email;
        //        content.str3 = company;
        //        content.str4 = note;
        //        SendMail(content);
        //        return Json(new
        //        {
        //            status = true
        //        });
        //    }
        //    else
        //    {
        //        return Json(new
        //        {
        //            status = false
        //        });
        //    }
        //}
        //private void SendMail(ContentMail content)
        //{
        //    string email = "ktdevsoft@gmail.com";
        //    ConfigSendMail(email, content);
        //    string email1 = "vinhtq@bluesea.vn";
        //    ConfigSendMail(email1, content);
        //    string email2 = "nguyenthemanh201186@gmail.com";
        //    ConfigSendMail(email2, content);
        //    string email3 = "ngaptk@bluesea.vn";
        //    ConfigSendMail(email3, content);
        //    string email4 = "linhhee2k@gmail.com";
        //    ConfigSendMail(email4, content);
        //}
        //public class ContentMail
        //{
        //    public string str { get; set; }
        //    public string str1 { get; set; }
        //    public string str2 { get; set; }
        //    public string str3 { get; set; }
        //    public string str4 { get; set; }
        //}
        //private void ConfigSendMail(string toEmail, ContentMail content)
        //{
        //    MailMessage mail = new MailMessage();
        //    mail.To.Add(toEmail);//mail khach hang
        //    mail.From = new MailAddress("thuedauso.vn@gmail.com");
        //    mail.Subject = "Phản hồi từ khách hàng - SEO";
        //    mail.Body = MailContent(content).ToString();//phan than mail
        //    mail.IsBodyHtml = true;

        //    SmtpClient smtp = new SmtpClient();
        //    smtp.Host = "smtp.gmail.com";
        //    smtp.Port = 587;
        //    smtp.EnableSsl = true;
        //    smtp.UseDefaultCredentials = true;
        //    smtp.Credentials = new NetworkCredential("thuedauso.vn@gmail.com", "Bongdapro");// tài khoản Gmail của bạn
            
        //    smtp.Send(mail);
        //}
        //private StringBuilder MailContent(ContentMail content)
        //{
        //    StringBuilder Body = new StringBuilder();
        //    Body.Append("<p>Đăng ký ngay</p>");
        //    Body.Append("<table>");
        //    Body.Append("<tr><td colspan='2'><h4>Thông tin khách hàng</h4></td></tr>");
        //    Body.Append("<tr><td>Họ và tên:</td><td>" + content.str + "</td></tr>");
        //    Body.Append("<tr><td>Điện thoại:</td><td>" + content.str1 + "</td></tr>");
        //    Body.Append("<tr><td>Công ty:</td><td>" + content.str3 + "</td></tr>");
        //    Body.Append("<tr><td>Email:</td><td>" + content.str2 + "</td></tr>");
        //    Body.Append("<tr><td>Ghi chú:</td><td>" + content.str4 + "</td></tr>");
        //    Body.Append("</table>");
        //    return Body;
        //}

    }
}

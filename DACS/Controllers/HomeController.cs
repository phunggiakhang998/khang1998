using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DACS.Models;
using System.Web.Mvc;



namespace DACS.Controllers
{
    
    public class HomeController : Controller
    {
        dbQuanLyBanGiayDataContext db = new dbQuanLyBanGiayDataContext();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";
            return View();
        }

        public ActionResult Contact()
        {           
            return View();
        }
        [HttpPost]
        public ActionResult Contact(FormCollection collection, LienHe LH)
        {
            var firstname = collection["FirstName"];
            var lastname = collection["LastName"];
            var emailLH = collection["EmailLH"];
            var tieude = collection["TieuDe"];
            var tinnhan = collection["TinNhan"];
            var Lhe = db.LienHes.OrderByDescending(n => n.id).First();
            if (String.IsNullOrEmpty(firstname))
            {
                ViewData["Loi1"] = "First Name khách hàng không được bỏ trống !";
            }
            else if (String.IsNullOrEmpty(lastname))
            {
                ViewData["Loi2"] = "Last Name không được bỏ trống !";
            }
            else if (String.IsNullOrEmpty(emailLH))
            {
                ViewData["Loi3"] = "Email không được bỏ trống !";
            }
            else if (String.IsNullOrEmpty(tieude))
            {
                ViewData["Loi4"] = "Tiêu Đề không được bỏ trống !";
            }
            else if (String.IsNullOrEmpty(tinnhan))
            {
                ViewData["Loi5"] = "Nội Dung không được bỏ trống !";
            }
            else
           
            {
                LH.id = Lhe.id + 1;
                LH.FirstName = firstname;
                LH.LastName = lastname;
                LH.EmailLH = emailLH;
                LH.TieuDe = tieude;
                LH.TinNhan = tinnhan;
                db.LienHes.InsertOnSubmit(LH);
                db.SubmitChanges();
                return RedirectToAction("Index", "Home");

            }
            return View();
        }
        public ActionResult Men()
        {
            return View();
        }
        public ActionResult Women()
        {
            return View();
        }
        public ActionResult Product()
        {
            return View();
        }
        public ActionResult Details()
        {
            return View();
        }
        public ActionResult News()
        {
            return View();
        }
    }
}
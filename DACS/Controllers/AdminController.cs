using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DACS.Models;
using PagedList;
using PagedList.Mvc;
using System.IO;
using System.Web.Mvc;

namespace DACS.Controllers
{
    public class AdminController : Controller
    {
        dbQuanLyBanGiayDataContext db = new dbQuanLyBanGiayDataContext();
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(FormCollection collection)
        {
            var tendnad = collection["usernamead"];
            var matkhauad = collection["passwordad"];
            if (String.IsNullOrEmpty(tendnad))
            {
                ViewData["Loi1"] = "Phải nhập tên đăng nhập";
            }
            else if (String.IsNullOrEmpty(matkhauad))
            {
                ViewData["Loi2"] = "Phải nhập mật khẩu";
            }
            else
            {
                Admin ad = db.Admins.SingleOrDefault(n => n.UserAdmin == tendnad && n.PassAdmin == matkhauad);
                if (ad != null)
                {
                    //ViewBag.Thongbao = "Chúc mừng đăng nhập thành công";
                    Session["Taikhoanadmin"] = ad;
                    Session["usernamead"] = collection["usernamead"].ToString();

                    return RedirectToAction("Index", "Admin");
                }
                else
                    ViewBag.Thongbao = "Tên đăng nhập hoặc mật khẩu không đúng";
            }

            return View();
        }
    }
}
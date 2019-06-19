using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DACS.Models;
using PagedList.Mvc;
using PagedList;

namespace DACS.Controllers
{
    public class TimKiemController : Controller
    {
        dbQuanLyBanGiayDataContext db = new dbQuanLyBanGiayDataContext();
        // GET: TimKiem
        [HttpPost]
        public ActionResult KetQuaTimKiem(FormCollection f, int? page)
        {
            string sTukhoa = f["txtTimKiem"].ToString();
            ViewBag.TuKhoa = sTukhoa;
            List<Giay> lstKQTK = db.Giays.Where(n => n.TenSP.Contains(sTukhoa)).ToList();
            int pageNumber = (page ?? 1);
            int pageSize = 8;
            if (lstKQTK.Count == 0)
            {
                ViewBag.Thongbao = "Không tìm thấy sản phẩm nào";
                return View(db.Giays.OrderBy(n => n.TenSP).ToPagedList(pageNumber, pageSize));
            }
            //Phan trang
            ViewBag.Thongbao = "Đã tìm thấy " + lstKQTK.Count + " kết quả !";
            return View(lstKQTK.OrderBy(n => n.TenSP).ToPagedList(pageNumber, pageSize));
        }

        [HttpGet]
        public ActionResult KetQuaTimKiem(string sTukhoa, int? page)
        {
            ViewBag.TuKhoa = sTukhoa;
            List<Giay> lstKQTK = db.Giays.Where(n => n.TenSP.Contains(sTukhoa)).ToList();
            int pageNumber = (page ?? 1);
            int pageSize = 8;
            if (lstKQTK.Count == 0)
            {
                ViewBag.Thongbao = "Không tìm thấy sản phẩm nào";
                return View(db.Giays.OrderBy(n => n.TenSP).ToPagedList(pageNumber, pageSize));
            }
            //Phan trang
            ViewBag.Thongbao = "Đã tìm thấy " + lstKQTK.Count + " kết quả !";
            return View(lstKQTK.OrderBy(n => n.TenSP).ToPagedList(pageNumber, pageSize));
        }
    }
}
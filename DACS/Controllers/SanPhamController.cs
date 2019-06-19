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
    public class SanPhamController : Controller
    {
        dbQuanLyBanGiayDataContext db = new dbQuanLyBanGiayDataContext();
        // GET: SanPham
        public ActionResult SanPham()
        {
            var s = from ss in db.Giays select ss;
            return View(s);
        }

        public ActionResult Details(int id)
        {
            var details = db.Giays.Where(s => s.MaSP == id).First();
            return View(details);
        }

        public ActionResult ListSize(int id)
        {
            ViewBag.Size = new SelectList(db.SizeGiays.ToList().OrderBy(n => n.Size).Where(n => n.MaSP == id), "Size", "Size");

            var size = from ss in db.SizeGiays where ss.MaSP == id select ss;
            return View(size);
        }

        public ActionResult ThuongHieu()
        {
            var th = from tn in db.ThuongHieus select tn;
            return PartialView(th);
        }
        public ActionResult GiayTheoTH(int id)
        {
            var th = from ss in db.Giays where id == ss.MaTH select ss;
            return View(th);
        }
        //public ActionResult SanPham(int? page)
        //{
        //    int pageSize = 8;
        //    int pageNum = (page ?? 1);
        //    var sanphammoi = Listgiaymoi(100);
        //    return View(sanphammoi.ToPagedList(pageNum, pageSize));
        //}
        //private List<Giay> Listgiaymoi(int count)
        //{
        //    return db.Giays.OrderByDescending(a => a.NgayCapNhat).Take(count).ToList();
        //}

    }
}
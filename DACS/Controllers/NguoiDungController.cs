using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DACS.Models;
using System.Web.Mvc;

namespace DACS.Controllers
{
    public class NguoiDungController : Controller
    {
        dbQuanLyBanGiayDataContext db = new dbQuanLyBanGiayDataContext();
        // GET: NguoiDung
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult DangKy()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Dangky(FormCollection collect, KhachHang kh)
        {
            var hoten = collect["HoTen"];
            var tendn = collect["Taikhoan"];
            var matkhau = collect["Matkhau"];
            var matkhaunhaplai = collect["matkhaukhnhaplai"];
            var diachi = collect["DiaChi"];
            var gioitinh = collect["GioiTinh"]; 
            var email = collect["Email"];
            var dienthoai = collect["DienThoai"];
            var ngaysinh = string.Format("{0:mm/dd/yyyy}", collect["ngaysinh"]);
            int lenght = matkhau.Length;
            if (String.IsNullOrEmpty(hoten))
            {
                ViewData["Loi1"] = "Họ tên khách hàng không được bỏ trống !";
            }
            else
            if (String.IsNullOrEmpty(tendn))
            {
                ViewData["Loi2"] = "Tên đăng nhập không được bỏ trống !";
            }
            else
            if (String.IsNullOrEmpty(matkhau))
            {
                ViewData["Loi3"] = "Mật khẩu không được bỏ trống !";
            }
            else if(lenght<6)
            {
                ViewData["Loilenght"] = "Mật khẩu phải từ 6 ký tự trở lên !";
            }
            else
            if (String.IsNullOrEmpty(matkhaunhaplai) || matkhau.ToString() != matkhaunhaplai.ToString())
            {
                ViewData["Loi4"] = "Mật khẩu nhập lại sai!";
            }
            else
            if (String.IsNullOrEmpty(diachi))
            {
                ViewData["Loi5"] = "Địa chi khách hàng không được bỏ trống !";
            }
            else
            if(String.IsNullOrEmpty(gioitinh))
            {
                ViewData["Loi6"] = "Giới tính khánh hàng không được bỏ trống !";
            }
            else
            if (String.IsNullOrEmpty(email))
            {
                ViewData["Loi7"] = "Email khách hàng không được bỏ trống !";
            }
            else
            if (String.IsNullOrEmpty(dienthoai))
            {
                ViewData["Loi8"] = "Điện thoại khách hàng không được bỏ trống !";
            }
            else
            if (String.IsNullOrEmpty(ngaysinh))
            {
                ViewData["Loi9"] = "Ngày sinh khách hàng không được bỏ trống !";
            }
            else
            {
                kh.HoTen = hoten;
                kh.Taikhoan = tendn;
                kh.Matkhau = matkhau;
                kh.DiaChi = diachi;
                kh.GioiTinh = gioitinh;
                kh.Email = email;
                kh.DienThoai = dienthoai;
                kh.NgaySinh = DateTime.Parse(ngaysinh);
                db.KhachHangs.InsertOnSubmit(kh);
                db.SubmitChanges();
                return RedirectToAction("DangNhap");
            }
            return this.DangKy();
        }
        [HttpGet]
        public ActionResult DangNhap()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Dangnhap(FormCollection collection)
        {
            var tendn = collection["Taikhoan"];
            var matkhau = collection["Matkhau"];
            if (String.IsNullOrEmpty(tendn))
            {
                ViewData["Loi1"] = "Phải nhập tên đăng nhập";
            }
            else if (String.IsNullOrEmpty(matkhau))
            {
                ViewData["Loi2"] = "Phải nhập mật khẩu";
            }
            else
            {
               KhachHang kh = db.KhachHangs.SingleOrDefault(n => n.Taikhoan == tendn && n.Matkhau == matkhau);
                if (kh != null)
                {
                    ViewBag.Thongbao = "Chúc mừng đăng nhập thành công";
                    Session["Taikhoankh"] = kh;
                    Session["Tentkh"] = collection["Taikhoan"].ToString();
                    Session["tendn"] = tendn.ToString();
                    return RedirectToAction("Index", "Home");
                }
                else
                    ViewBag.Thongbao = "Tên đăng nhập hoặc mật khẩu không đúng";
            }
            return View();
        }
        public ActionResult DangXuat()
        {
            Session["Taikhoankh"] = null;
            
            Session["GioHang"] = null;
            return RedirectToAction("Index", "Home");
        }
        
    }
}
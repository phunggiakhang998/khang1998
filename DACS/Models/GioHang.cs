using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DACS.Models;

namespace DACS.Models
{
    public class GioHang
    {
        dbQuanLyBanGiayDataContext data = new dbQuanLyBanGiayDataContext();
        public int iMaSP { set; get; }
        public string sTenSP { set; get; }
        public string sHinhAnh { set; get; }
        public double dGiaBan { set; get; }
        public int iSoluong { set; get; }
        public int iSize { set; get; }
        public double dThanhtien
        {
            get { return iSoluong * dGiaBan; }
        }

        public GioHang(int MaSP)
        {
            iMaSP = MaSP;
            Giay g = data.Giays.Single(n => n.MaSP == iMaSP);
            sTenSP = g.TenSP;
            sHinhAnh = g.HinhAnh;
            dGiaBan = double.Parse(g.GiaBan.ToString());
            iSoluong = 0;
            iSize = 0;
        }
    }
}
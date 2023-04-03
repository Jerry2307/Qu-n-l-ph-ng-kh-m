using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DACN.Models;

namespace DACN.Areas.admin.Controllers
{
    public class TrangChuAdminController : Controller
    {
        // GET: admin/TrangChuAdmin
        QLPhongKhamDaKhoaEntities4 db = new QLPhongKhamDaKhoaEntities4();
        public ActionResult Index()
        {
            ViewBag.TongBenhNhan = ThongKeBenhNhan();
            ViewBag.TongDichVu = ThongKeDichVu();
            ViewBag.TongBacSi = ThongKeBacSi();
            return View(db.DatLichKhams.ToList());
        }

        private dynamic ThongKeBacSi()
        {
            double slBS = db.BacSis.Count();
            return slBS;
        }

        private dynamic ThongKeDichVu()
        {
            double slDV = db.DichVus.Count();
            return slDV;
        }
        public dynamic ThongKeBenhNhan()
        {
            double slBN = db.BenhNhans.Count();
            return slBN;
        }
        //public ActionResult ChiTietLichKham(int id)
        //{
        //    ViewBag.TongTien = TongTienDonHang(id);
        //    var ctDH = db.ChiTietDonHangs.Where(m => m.MaDonHang == id).ToList();
        //    return View(ctDH);
        //}
    }
}
using DACN.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DACN.Areas.admin.Controllers
{
    public class LoginController : Controller
    {
        // GET: admin/Login
        QLPhongKhamDaKhoaEntities4 db = new QLPhongKhamDaKhoaEntities4();
        public ActionResult DangNhapAdmin()
        {
            return View();
        }

        [HttpPost]
        public ActionResult DangNhapAdmin(FormCollection collection)
        {
            var tendn = collection["UserName"];
            var matkhau = collection["PassWord"];
            var hoten = collection["HoTen"];
            if (String.IsNullOrEmpty(tendn))
            {
                ViewData["Loi1"] = "Phải nhập UserName";
            }
            else if (String.IsNullOrEmpty(matkhau))
            {
                ViewData["Loi2"] = "Phải nhập PassWord";
            }
            else
            {
                Admin ad = db.Admins.SingleOrDefault(n => n.TaiKhoan == tendn && n.MatKhau == matkhau);
                if (ad != null)
                {
                    Session["TaiKhoanadmin"] = ad;
                    Session["HoTen"] = ad.HoTen;
                    return RedirectToAction("Index", "TrangChuAdmin");
                }
                else
                {
                    ViewBag.ThongBao = "Tên đăng nhập chưa chính xác!";
                }
            }
            return View();
        }
        public RedirectToRouteResult DangXuat()
        {
            Session["TaiKhoanadmin"] = null;
            return RedirectToAction("DangNhapAdmin", "Login");
        }
    }
}

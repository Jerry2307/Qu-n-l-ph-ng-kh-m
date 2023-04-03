using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DACN.Models;
using DACN.Common;

namespace DACN.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        QLPhongKhamDaKhoaEntities4 db = new QLPhongKhamDaKhoaEntities4();
        public ActionResult DangNhap()
        {
            return View();
        }

        [HttpPost]
        public ActionResult DangNhap(FormCollection collection)
        {
            var tendangnhap = collection["TenDangNhap"];
            var matkhau = collection["MatKhau"];

            if (string.IsNullOrEmpty(tendangnhap))
            {
                ViewData["loi1"] = "Tên đăng nhập không được để trống";
            }
            else if (string.IsNullOrEmpty(matkhau))
            {
                ViewData["loi2"] = "Mật Khẩu không được để trống";
            }
            else
            {
                BenhNhan bn = db.BenhNhans.SingleOrDefault(n => n.TenDangNhap == tendangnhap && n.MatKhau == matkhau);
                if (bn != null)
                {
                    ViewBag.ThongBao = "Bạn đã đăng nhập thành công";
                    Session["TaiKhoan"] = bn;
                    Session["HoTen"] = bn.HoTen;
                    Session["MaBenhNhan"] = bn.MaBenhNhan;
                    Session["GioiTinh"] = bn.GioiTinh;
                    return RedirectToAction("TrangChuUser", "TrangChu");
                }
                else
                {
                    ViewBag.KhongThanh = "Tài khoản hoặc mật khẩu không đúng";
                    return this.DangNhap();
                }
            }
            return View();
        }

        [HttpGet]
        public ActionResult DangKy()
        {
            return View();
        }

        [HttpPost]
        public ActionResult DangKy(FormCollection collection, BenhNhan bn)
        {
            var hoten = collection["HoTen"];
            var tendangnhap = collection["TenDangNhap"];
            var matkhau = collection["MatKhau"];
            var namsinh = collection["NamSinh"];
            var email = collection["Email"];
            var gioitinh = collection["GioiTinh"];
            var cmnd_cccd = collection["CMND_CCCD"];
            var dantoc = collection["DanToc"];
            var diachi = collection["DiaChi"];
            var sdt = collection["SDT"];

            if (string.IsNullOrEmpty(hoten))
            {
                ViewData["loi1"] = "Phải nhập họ tên";
            }
            else if (string.IsNullOrEmpty(tendangnhap))
            {
                ViewData["loi2"] = "Phải nhập tài khoản";
            }
            else if (string.IsNullOrEmpty(matkhau))
            {
                ViewData["loi3"] = "Phải nhập mật khẩu";
            }
            else if (string.IsNullOrEmpty(namsinh))
            {
                ViewData["loi4"] = "Phải nhập năm sinh";
            }
            else if (string.IsNullOrEmpty(email))
            {
                ViewData["loi5"] = "Phải nhập email";
            }
            else if (string.IsNullOrEmpty(cmnd_cccd))
            {
                ViewData["loi6"] = "Phải nhập CMND/CCCD";
            }
            else if (string.IsNullOrEmpty(dantoc))
            {
                ViewData["loi7"] = "Phải nhập dân tộc";
            }
            else if (string.IsNullOrEmpty(diachi))
            {
                ViewData["loi8"] = "Phải nhập địa chỉ";
            }
            else if (string.IsNullOrEmpty(sdt))
            {
                ViewData["loi9"] = "Phải nhập số điện thoại";
            }
            else
            {
                bn.HoTen = hoten;
                bn.TenDangNhap = tendangnhap;
                bn.MatKhau = matkhau;
                bn.NamSinh = namsinh;
                bn.Email = email;
                bn.GioiTinh = Boolean.Parse(gioitinh);
                bn.CMND_CCCD = cmnd_cccd;
                bn.DanToc = dantoc;
                bn.DiaChi = diachi;
                bn.SDT = sdt;

                db.BenhNhans.Add(bn);
                db.SaveChanges();

                string content = System.IO.File.ReadAllText(Server.MapPath("~/template/DangKy.html"));

                content = content.Replace("{{CustomerName}}", bn.HoTen);
                content = content.Replace("{{tendangnhap}}", tendangnhap.ToString());
                content = content.Replace("{{matkhau}}", matkhau.ToString());
                content = content.Replace("{{namsinh}}", namsinh.ToString());
                content = content.Replace("{{email}}", email.ToString());
                content = content.Replace("{{gioitinh}}", gioitinh.ToString());
                content = content.Replace("{{cmnd_cccd}}", cmnd_cccd.ToString());
                content = content.Replace("{{dantoc}}", dantoc.ToString());
                content = content.Replace("{{diachi}}", diachi.ToString());
                content = content.Replace("{{sdt}}", sdt.ToString());

                var toEmail = ConfigurationManager.AppSettings["ToEmailAddress"].ToString();
                new MailHelper().SendMail(toEmail, "Tạo tài khoản thành công", content);

                return RedirectToAction("DangNhap");
            }
            return this.DangKy();
        }

        public RedirectToRouteResult DangXuat()
        {
            List<BenhNhan> tk = Session["TaiKhoan"] as List<BenhNhan>;
            Session["TaiKhoan"] = null;
            return RedirectToAction("TrangChuUser", "TrangChu");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
using DACN.Common;
using DACN.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.WebPages;

namespace DACN.Controllers
{
    public class DatLichController : Controller
    {
        // GET: DatLichKham
        QLPhongKhamDaKhoaEntities4 db = new QLPhongKhamDaKhoaEntities4();
        public ActionResult DatLich(int MaBenhNhan)
        {
            if (Session["Taikhoan"] == null || Session["Taikhoan"].ToString() == "")
            {
                return RedirectToAction("DangNhap", "User");
            }
            BenhNhan bn = db.BenhNhans.Find(MaBenhNhan);
            if (bn == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaDichVu = new SelectList(db.DichVus.ToList().OrderBy(n => n.TenDichVu), "MaDichVu", "TenDichVu");
            ViewBag.MaChuyenKhoa = new SelectList(db.ChuyenKhoas.ToList().OrderBy(n => n.TenChuyenKhoa), "MaChuyenKhoa", "TenChuyenKhoa");
            ViewBag.MaBacSi = new SelectList(db.BacSis.ToList().OrderBy(n => n.TenBacSi), "MaBacSi", "TenBacSi");
            return View(bn);
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DatLich(FormCollection collection, BenhNhan bn, DatLichKham dlk, DichVu dv, BacSi bs, string NgayDatLich)
        {
            ViewBag.MaDichVu = new SelectList(db.DichVus.ToList().OrderBy(n => n.TenDichVu), "MaDichVu", "TenDichVu");
            ViewBag.MaChuyenKhoa = new SelectList(db.ChuyenKhoas.ToList().OrderBy(n => n.TenChuyenKhoa), "MaChuyenKhoa", "TenChuyenKhoa");
            ViewBag.MaBacSi = new SelectList(db.BacSis.ToList().OrderBy(n => n.TenBacSi), "MaBacSi", "TenBacSi");
            DateTime ndl = DateTime.Parse(NgayDatLich);

            var hoten = collection["hoten"];
            var gioitinh = collection["gioitinh"];
            var thoigiankham = String.Format("{0:MM/dd/yyyy HH:mm}", collection["NgayDatLich"]);
            var email = collection["email"];
            var sdt = collection["sdt"];
            var chuyenkhoa = collection["chuyenkhoa"];
            var bacsi = collection["bacsi"];
            var trieuchung = collection["trieuchung"];

            if (ndl < DateTime.Now)
            {
                Session["loi1"] = "Ngày phải lớn hơn ngày hiện tại";
                return RedirectToAction("DatLich", "DatLich", new { MaBenhNhan = Session["MaBenhNhan"] });
            }
            else if (string.IsNullOrEmpty(trieuchung))
            {
                ViewData["loi2"] = "Hãy ghi rõ triệu chứng của bạn";
            }
            else
            {
                dv.MaDichVu = dlk.MaDichVu;
                bn.HoTen = hoten;
                bn.GioiTinh = gioitinh.AsBool();
                dlk.NgayDatLich = DateTime.Parse(thoigiankham);
                dlk.MaBacSi = bs.MaBacSi;
                dlk.TrieuChung = trieuchung;
                db.DatLichKhams.Add(dlk);
                db.SaveChanges();

                string content = System.IO.File.ReadAllText(Server.MapPath("~/template/newDatLich.html"));

                content = content.Replace("{{CustomerName}}", bn.HoTen);
                content = content.Replace("{{gioitinh}}", gioitinh);
                content = content.Replace("{{dichvu}}", dlk.DichVu.TenDichVu.ToString());
                content = content.Replace("{{thoigiankham}}", thoigiankham);
                content = content.Replace("{{email}}", email.ToString());
                content = content.Replace("{{sdt}}", sdt.ToString());
                content = content.Replace("{{chuyenkhoa}}", dlk.BacSi.ChuyenKhoa.TenChuyenKhoa.ToString());
                content = content.Replace("{{bacsi}}", dlk.BacSi.TenBacSi.ToString());
                content = content.Replace("{{trieuchung}}", trieuchung.ToString());

                var toEmail = ConfigurationManager.AppSettings["ToEmailAddress"].ToString();
                new MailHelper().SendMail(email, "Bệnh nhân đặt lịch khám", content);
                new MailHelper().SendMail(toEmail, "Đặt lịch khám thành công", content);
                return RedirectToAction("ThongBaoDatLich", "ThongBao");
            }
            return View();
        }
    }
}
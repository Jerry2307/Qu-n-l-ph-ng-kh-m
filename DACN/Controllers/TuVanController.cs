using DACN.Models;
using DACN.Common;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DACN.Controllers
{
    public class TuVanController : Controller
    {
        // GET: TuVan
        QLPhongKhamDaKhoaEntities4 db = new QLPhongKhamDaKhoaEntities4();
        public ActionResult TuVan()
        {
            ViewBag.MaChuyenKhoa = new SelectList(db.ChuyenKhoas.ToList().OrderBy(n => n.TenChuyenKhoa), "MaChuyenKhoa", "TenChuyenKhoa");
            ViewBag.MaBacSi = new SelectList(db.BacSis.ToList().OrderBy(n => n.TenBacSi), "MaBacSi", "TenBacSi");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult TuVan(FormCollection collection, TuVan tv, BacSi bs)
        {
            ViewBag.MaChuyenKhoa = new SelectList(db.ChuyenKhoas.ToList().OrderBy(n => n.TenChuyenKhoa), "MaChuyenKhoa", "TenChuyenKhoa");
            ViewBag.MaBacSi = new SelectList(db.BacSis.ToList().OrderBy(n => n.TenBacSi), "MaBacSi", "TenBacSi");

            var hoten = collection["hoten"];
            var email = collection["email"];
            var sdt = collection["sdt"];
            var chuyenkhoa = collection["chuyenkhoa"];
            var bacsi = collection["bacsi"];
            var nd = collection["nd"];

            if (string.IsNullOrEmpty(hoten))
            {
                ViewData["loi1"] = "Họ tên không được để trống";
            }
            else if (string.IsNullOrEmpty(email))
            {
                ViewData["loi3"] = "Email không được để trống";
            }
            else if (string.IsNullOrEmpty(sdt))
            {
                ViewData["loi4"] = "Số điện thoại không được để trống";
            }
            else if (string.IsNullOrEmpty(nd))
            {
                ViewData["loi5"] = "Nội dung không được để trống";
            }
            else
            {
                tv.HoTen = hoten;
                tv.Email = email;
                tv.SDT = sdt;
                tv.MaBacSi = bs.MaBacSi;
                tv.NDTuVan = nd;
                db.TuVans.Add(tv);
                db.SaveChanges();

                string content = System.IO.File.ReadAllText(Server.MapPath("~/template/newemail.html"));

                content = content.Replace("{{CustomerName}}", tv.HoTen);
                content = content.Replace("{{email}}", email.ToString());
                content = content.Replace("{{sdt}}", sdt.ToString());
                content = content.Replace("{{chuyenkhoa}}", tv.BacSi.ChuyenKhoa.TenChuyenKhoa.ToString());
                content = content.Replace("{{bacsi}}", tv.BacSi.TenBacSi.ToString());
                content = content.Replace("{{sdt}}", sdt.ToString());
                content = content.Replace("{{nd}}", nd.ToString());

                var toEmail = ConfigurationManager.AppSettings["ToEmailAddress"].ToString();
                new MailHelper().SendMail(email, "Bệnh nhân gửi thư tư vấn", content);
                new MailHelper().SendMail(toEmail, "Gửi thư tư vấn thành công", content);
                return RedirectToAction("ThongBaoTuVan", "ThongBao");
            }
            return this.TuVan();
        }
    }
}
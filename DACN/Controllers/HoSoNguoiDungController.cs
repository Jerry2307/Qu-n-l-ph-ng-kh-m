using DACN.Common;
using DACN.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace DACN.Controllers
{
    public class HoSoNguoiDungController : Controller
    {
        // GET: HoSoNguoiDung
        QLPhongKhamDaKhoaEntities4 db = new QLPhongKhamDaKhoaEntities4();
        public ActionResult HoSoUser(int MaBenhNhan)
        {
            BenhNhan bn = db.BenhNhans.Find(MaBenhNhan);
            if (bn == null)
            {
                return HttpNotFound();
            }   
            return View(bn);
        }

        [HttpGet]
        public ActionResult ChangePassword(int MaBenhNhan)
        {
            var bn = db.BenhNhans.First(n => n.MaBenhNhan == MaBenhNhan);
            if (bn == null)
            {
                return HttpNotFound();
            }
            return View(bn);
        }

        [HttpPost]
        public ActionResult ChangePassword(int MaBenhNhan, FormCollection f)
        { 
            var E_BenhNhans = db.BenhNhans.First(n => n.MaBenhNhan == MaBenhNhan);

            var E_MatKhau = (f["MatKhauCu"]);
            var MatKhauMoi = f["MatKhauMoi"];
            var XacNhanMatKhau = f["XacNhanMatKhau"];

            E_BenhNhans.MaBenhNhan = MaBenhNhan;
            if (!E_BenhNhans.MatKhau.Equals(E_MatKhau))
            {
                ViewData["NhapMKCu"] = "Mật khẩu không đúng!";
                return View();
            }
            else if (String.IsNullOrEmpty(XacNhanMatKhau))
            {
                ViewData["NhapMKXN"] = "Phải nhập mật khẩu xác nhận!";
            }
            else
            {
                if (MatKhauMoi != XacNhanMatKhau)
                {
                    ViewData["MatKhauGiongNhau"] = "Mật khẩu và xác nhận mật khẩu xác nhận phải giống nhau";
                }
                else
                {
                    E_BenhNhans.TenDangNhap = E_BenhNhans.TenDangNhap;
                    E_BenhNhans.MatKhau = MatKhauMoi;

                    db.Configuration.ValidateOnSaveEnabled = false;
                    TryUpdateModel(E_BenhNhans);
                    db.SaveChanges();

                    string content = System.IO.File.ReadAllText(Server.MapPath("~/template/ChangePassword.html"));

                    content = content.Replace("{{CustomerName}}", E_BenhNhans.HoTen.ToString());
                    content = content.Replace("{{taiKhoan}}", E_BenhNhans.TenDangNhap.ToString());
                    content = content.Replace("{{matkhaucu}}", E_MatKhau.ToString());
                    content = content.Replace("{{matkhaumoi}}", MatKhauMoi.ToString());

                    var toEmail = ConfigurationManager.AppSettings["ToEmailAddress"].ToString();
                    new MailHelper().SendMail(toEmail, "Người dùng đổi mật khẩu từ Bệnh viện DN", content);

                    return RedirectToAction("HoSoUser", "HoSoNguoiDung", new { MaBenhNhan = Session["MaBenhNhan"] });
                }
            }
            return View();
        }
        public ActionResult ThayDoiThongTin(int MaBenhNhan)
        {
            BenhNhan bn = db.BenhNhans.First(n => n.MaBenhNhan == MaBenhNhan);
            if (bn == null)
            {
                return HttpNotFound();
            }
            return View(bn);
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult ThayDoiThongTin(BenhNhan benhNhan, HttpPostedFileBase fileUpload)
        {
            //kiem tra duong dan file
            if (fileUpload == null)
            {
                ViewBag.ThongBao = "Vui lòng chọn ảnh";
                return View();
            }
            //them vao csdl
            else
            {
                if (ModelState.IsValid)
                {
                    //Luu ten file
                    var fileName = Path.GetFileName(fileUpload.FileName);
                    //luu duong dan cua file
                    var path = Path.Combine(Server.MapPath("~/HinhAnh"), fileName);
                    //kiem tra hinh anh da ton tai chua?
                    if (System.IO.File.Exists(path))
                    {
                        ViewBag.ThongBao = "Hình ảnh đã tồn tại";
                    } 
                    else
                    {
                        //luu hinh anh vao duong dan
                        fileUpload.SaveAs(path);
                    }
                    benhNhan.Anh = fileName;

                    db.Entry(benhNhan).State = EntityState.Modified;
                    UpdateModel(benhNhan);
                    db.SaveChanges();
                }
                return RedirectToAction("TrangChuUser", "TrangChu");
            } 
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
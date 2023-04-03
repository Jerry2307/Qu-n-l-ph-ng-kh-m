using DACN.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;

namespace DACN.Areas.admin.Controllers
{
    public class BacSiController : Controller
    {
        // GET: admin/BacSi
        QLPhongKhamDaKhoaEntities4 db = new QLPhongKhamDaKhoaEntities4();
        public ActionResult Index()
        {
            return View(db.BacSis.ToList());
        }

        // GET: admin/BacSi/Create
        public ActionResult Create()
        {
            ViewBag.MaChuyenKhoa = new SelectList(db.ChuyenKhoas.ToList().OrderBy(n => n.TenChuyenKhoa), "MaChuyenKhoa", "TenChuyenKhoa");
            return View();
        }

        // POST: admin/BacSi/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaBacSi, MaChuyenKhoa, TenBacSi, Tuoi, Anh, SDT, Email, TrinhDo, KinhNghiem")] BacSi bacSi, HttpPostedFileBase fileUpload)
        {
            ViewBag.MaChuyenKhoa = new SelectList(db.ChuyenKhoas.ToList().OrderBy(n => n.TenChuyenKhoa), "MaChuyenKhoa", "TenChuyenKhoa");
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
                    bacSi.Anh = fileName;

                    db.Entry(bacSi).State = EntityState.Added;
                    UpdateModel(bacSi);
                    db.SaveChanges();
                }
                return RedirectToAction("Index", "BacSi");
            }
        }

        // GET: Admin/BacSi/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BacSi bacSi = db.BacSis.Find(id);
            if (bacSi == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaChuyenKhoa = new SelectList(db.ChuyenKhoas.ToList().OrderBy(n => n.TenChuyenKhoa), "MaChuyenKhoa", "TenChuyenKhoa");
            return View(bacSi);
        }

        // POST: Admin/BacSi/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(BacSi bacSi, HttpPostedFileBase fileUpload)
        {
            ViewBag.MaChuyenKhoa = new SelectList(db.ChuyenKhoas.ToList().OrderBy(n => n.TenChuyenKhoa), "MaChuyenKhoa", "TenChuyenKhoa");
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
                    bacSi.Anh = fileName;
                    //luu vao csdl
                    db.Entry(bacSi).State = EntityState.Modified;
                    UpdateModel(bacSi);
                    db.SaveChanges();
                }
                return RedirectToAction("Index");
            }
        }

        // GET: admin/ChuyenKhoa/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BacSi bacSi = db.BacSis.Find(id);
            if (bacSi == null)
            {
                return HttpNotFound();
            }
            return View(bacSi);
        }

        // GET: admin/BacSi/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BacSi bacSi = db.BacSis.Find(id);
            if (bacSi == null)
            {
                return HttpNotFound();
            }
            return View(bacSi);
        }

        // POST: admin/BacSi/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BacSi bacSi = db.BacSis.Find(id);
            db.BacSis.Remove(bacSi);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
using DACN.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace DACN.Areas.admin.Controllers
{
    public class HoSoBenhAnController : Controller
    {
        QLPhongKhamDaKhoaEntities4 db = new QLPhongKhamDaKhoaEntities4();

        // GET: admin/HoSoBenhAn
        public ActionResult Index()
        {
            return View(db.HoSoBenhAns.ToList());
        }

        // GET: admin/HoSoBenhAn/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HoSoBenhAn hoSoBenhAn = db.HoSoBenhAns.Find(id);
            if (hoSoBenhAn == null)
            {
                return HttpNotFound();
            }
            return View(hoSoBenhAn);
        }

        // GET: Admin/HoSoBenhNhan/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HoSoBenhAn hoSoBenhAn = db.HoSoBenhAns.Find(id);
            if (hoSoBenhAn == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaBenhNhan = new SelectList(db.BenhNhans.ToList().OrderBy(n => n.HoTen), "MaBenhNhan", "HoTen");
            ViewBag.MaNguoiThan = new SelectList(db.NguoiThans.ToList().OrderBy(n => n.HoTen), "MaNguoiThan", "HoTen");
            return View(hoSoBenhAn);
        }

        // POST: Admin/HoSoBenhNhan/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaHoSo, MaBenhNhan, NgayNhapVien, NgayXuatVien, TomTatBenhAn, MaNguoiThan")] HoSoBenhAn hoSoBenhAn)
        {
            ViewBag.MaBenhNhan = new SelectList(db.BenhNhans.ToList().OrderBy(n => n.HoTen), "MaBenhNhan", "HoTen");
            ViewBag.MaNguoiThan = new SelectList(db.NguoiThans.ToList().OrderBy(n => n.HoTen), "MaNguoiThan", "HoTen");
            if (ModelState.IsValid)
            {
                db.Entry(hoSoBenhAn).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(hoSoBenhAn);
        }

        // GET: admin/HoSoBenhAn/Create
        public ActionResult Create()
        {
            ViewBag.MaBenhNhan = new SelectList(db.BenhNhans.ToList().OrderBy(n => n.HoTen), "MaBenhNhan", "HoTen");
            ViewBag.MaNguoiThan = new SelectList(db.NguoiThans.ToList().OrderBy(n => n.HoTen), "MaNguoiThan", "HoTen");
            return View();
        }

        // POST: admin/HoSoBenhAn/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaHoSo, MaBenhNhan, NgayNhapVien, NgayXuatVien, TomTatBenhAn, MaNguoiThan")] HoSoBenhAn hoSoBenhAn)
        {
            ViewBag.MaBenhNhan = new SelectList(db.BenhNhans.ToList().OrderBy(n => n.HoTen), "MaBenhNhan", "HoTen");
            ViewBag.MaNguoiThan = new SelectList(db.NguoiThans.ToList().OrderBy(n => n.HoTen), "MaNguoiThan", "HoTen");
            if (ModelState.IsValid)
            {
                db.HoSoBenhAns.Add(hoSoBenhAn);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(hoSoBenhAn);
        }

        // GET: admin/HoSoBenhNhan/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HoSoBenhAn hoSoBenhAn = db.HoSoBenhAns.Find(id);
            if (hoSoBenhAn == null)
            {
                return HttpNotFound();
            }
            return View(hoSoBenhAn);
        }

        // POST: admin/HoSoBenhNhan/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            HoSoBenhAn hoSoBenhAn = db.HoSoBenhAns.Find(id);
            db.HoSoBenhAns.Remove(hoSoBenhAn);
            db.SaveChanges();
            return RedirectToAction("Index");
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
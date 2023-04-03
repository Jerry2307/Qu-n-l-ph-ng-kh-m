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
    public class NguoiThanController : Controller
    {
        // GET: admin/NguoiThan
        QLPhongKhamDaKhoaEntities4 db = new QLPhongKhamDaKhoaEntities4();
        public ActionResult Index()
        {
            return View(db.NguoiThans.ToList());
        }

        // GET: admin/NguoiThan/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: admin/NguoiThan/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaNguoiThan, HoTen, NamSinh")] NguoiThan nguoiThan)
        {
            if (ModelState.IsValid)
            {
                db.NguoiThans.Add(nguoiThan);
                
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(nguoiThan);
        }

        // GET: Admin/NguoiThan/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NguoiThan nguoiThan = db.NguoiThans.Find(id);
            if (nguoiThan == null)
            {
                return HttpNotFound();
            }
            return View(nguoiThan);
        }

        // POST: Admin/NguoiThan/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaNguoiThan, HoTen, NamSinh")] NguoiThan nguoiThan)
        {
            if (ModelState.IsValid)
            {
                db.Entry(nguoiThan).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(nguoiThan);
        }

        // GET: admin/NguoiThan/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NguoiThan nguoiThan = db.NguoiThans.Find(id);
            if (nguoiThan == null)
            {
                return HttpNotFound();
            }
            return View(nguoiThan);
        }

        // GET: admin/NguoiThan/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NguoiThan nguoiThan = db.NguoiThans.Find(id);
            if (nguoiThan == null)
            {
                return HttpNotFound();
            }
            return View(nguoiThan);
        }

        // POST: admin/NguoiThan/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            NguoiThan nguoiThan = db.NguoiThans.Find(id);
            db.NguoiThans.Remove(nguoiThan);
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
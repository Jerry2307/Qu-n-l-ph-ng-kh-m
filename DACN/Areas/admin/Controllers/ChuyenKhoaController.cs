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
    public class ChuyenKhoaController : Controller
    {
        // GET: admin/ChuyenKhoa
        QLPhongKhamDaKhoaEntities4 db = new QLPhongKhamDaKhoaEntities4();
        public ActionResult Index()
        {
            return View(db.ChuyenKhoas.ToList());
        }

        // GET: admin/ChuyenKhoa/Create
        public ActionResult Create()
        {
            ViewBag.MaChuyenKhoa = new SelectList(db.ChuyenKhoas.ToList().OrderBy(n => n.TenChuyenKhoa), "MaChuyenKhoa", "TenChuyenKhoa");
            return View();
        }

        // POST: admin/ChuyenKhoa/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaChuyenKhoa, TenChuyenKhoa")] ChuyenKhoa chuyenKhoa)
        {
            ViewBag.MaChuyenKhoa = new SelectList(db.ChuyenKhoas.ToList().OrderBy(n => n.TenChuyenKhoa), "MaChuyenKhoa", "TenChuyenKhoa");
            if (ModelState.IsValid)
            {
                db.ChuyenKhoas.Add(chuyenKhoa);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(chuyenKhoa);
        }

        // GET: Admin/ChuyenKhoa/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ChuyenKhoa chuyenKhoa = db.ChuyenKhoas.Find(id);
            if (chuyenKhoa == null)
            {
                return HttpNotFound();
            }
            return View(chuyenKhoa);
        }

        // POST: Admin/ChuyenKhoa/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaChuyenKhoa, TenChuyenKhoa")] ChuyenKhoa chuyenKhoa)
        {
            if (ModelState.IsValid)
            {
                db.Entry(chuyenKhoa).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(chuyenKhoa);
        }

        // GET: admin/ChuyenKhoa/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ChuyenKhoa chuyenKhoa = db.ChuyenKhoas.Find(id);
            if (chuyenKhoa == null)
            {
                return HttpNotFound();
            }
            return View(chuyenKhoa);
        }

        // GET: admin/ChuyenKhoa/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ChuyenKhoa chuyenKhoa = db.ChuyenKhoas.Find(id);
            if (chuyenKhoa == null)
            {
                return HttpNotFound();
            }
            return View(chuyenKhoa);
        }

        // POST: admin/ChuyenKhoa/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ChuyenKhoa chuyenKhoa = db.ChuyenKhoas.Find(id);
            db.ChuyenKhoas.Remove(chuyenKhoa);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
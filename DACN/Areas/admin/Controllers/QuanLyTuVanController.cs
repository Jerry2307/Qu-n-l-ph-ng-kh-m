using DACN.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace DACN.Areas.admin.Controllers
{
    public class QuanLyTuVanController : Controller
    {
        // GET: admin/QuanLyTuVan
        QLPhongKhamDaKhoaEntities4 db = new QLPhongKhamDaKhoaEntities4();
        public ActionResult Index()
        {
            return View(db.TuVans.ToList());
        }

        // GET: admin/QuanLyTuVan/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TuVan tuVan = db.TuVans.Find(id);
            if (tuVan == null)
            {
                return HttpNotFound();
            }
            return View(tuVan);
        }

        // GET: admin/QuanLyTuVan/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TuVan tuVan = db.TuVans.Find(id);
            if (tuVan == null)
            {
                return HttpNotFound();
            }
            return View(tuVan);
        }

        // POST: admin/DichVu/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TuVan tuVan = db.TuVans.Find(id);
            db.TuVans.Remove(tuVan);
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
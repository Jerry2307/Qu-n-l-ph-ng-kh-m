using DACN.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace DACN.Areas.admin.Controllers
{
    public class BenhNhanController : Controller
    {
        // GET: admin/BenhNhan
        QLPhongKhamDaKhoaEntities4 db = new QLPhongKhamDaKhoaEntities4();

        public ActionResult Index()
        {
            return View(db.BenhNhans.ToList());
        }

        // GET: admin/BenhNhan/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BenhNhan benhNhan = db.BenhNhans.Find(id);
            if (benhNhan == null)
            {
                return HttpNotFound();
            }
            return View(benhNhan);
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

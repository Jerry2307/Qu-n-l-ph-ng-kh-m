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
    public class DatLichKhamController : Controller
    {
        // GET: admin/DatLichKham
        QLPhongKhamDaKhoaEntities4 db = new QLPhongKhamDaKhoaEntities4();
        public ActionResult Index()
        {
            return View(db.DatLichKhams.ToList());
        }

        // GET: admin/DatLichKham/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DatLichKham datLichKham = db.DatLichKhams.Find(id);
            if (datLichKham == null)
            {
                return HttpNotFound();
            }
            return View(datLichKham);
        }
    }
}
using DACN.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace DACN.Controllers
{
    public class DichVuKhamController : Controller
    {
        // GET: DichVu
        QLPhongKhamDaKhoaEntities4 db = new QLPhongKhamDaKhoaEntities4();
        public ActionResult DV()
        {
            var a = db.DichVus.ToList();
            return View(a);
        }
    }
}
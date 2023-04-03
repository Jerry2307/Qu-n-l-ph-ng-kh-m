using DACN.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

namespace DACN.Controllers
{
    public class HSBAController : Controller
    {
        // GET: HSBA
        QLPhongKhamDaKhoaEntities4 db = new QLPhongKhamDaKhoaEntities4();
        public ActionResult Index(int MaBenhNhan)
        {
            List<HoSoBenhAn> hsba = new List<HoSoBenhAn>();
            hsba = db.HoSoBenhAns.Where(b => b.MaBenhNhan == MaBenhNhan).ToList();
            return View(hsba);
        }
    }
}
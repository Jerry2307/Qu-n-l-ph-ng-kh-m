using DACN.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

namespace DACN.Controllers
{
    public class LichSuKhamController : Controller
    {
        // GET: LichSuKham
        QLPhongKhamDaKhoaEntities4 db = new QLPhongKhamDaKhoaEntities4();
        public ActionResult Index(int MaBenhNhan)
        {
            List<DatLichKham> datLichKhams = new List<DatLichKham>();
            datLichKhams = db.DatLichKhams.Where(b => b.MaBenhNhan == MaBenhNhan).ToList();
            return View(datLichKhams);
        }
    }
}
using DACN.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DACN.Controllers
{
    public class DoiNguBSController : Controller
    {
        // GET: DoiNguBS
        QLPhongKhamDaKhoaEntities4 db = new QLPhongKhamDaKhoaEntities4();
        public ActionResult DoiNguBS()
        {
            var bs = (from bacSi in db.BacSis select bacSi).ToList();
            return View(db.BacSis.ToList());
        }

        //public ActionResult ChuyenKhoaPartial()
        //{
        //    var ck = from cd in db.ChuyenKhoas select cd;
        //    return PartialView(ck);
        //}
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DACN.Models;

namespace DACN.Controllers
{
    public class TrangChuController : Controller
    {
        // GET: TrangChu
        QLPhongKhamDaKhoaEntities4 db = new QLPhongKhamDaKhoaEntities4();
        public ActionResult TrangChuUser()
        {
            return View();
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DACN.Controllers
{
    public class ThongBaoController : Controller
    {
        // GET: ThongBao
        public ActionResult ThongBaoDatLich()
        {
            return View();
        }

        public ActionResult ThongBaoTuVan()
        {
            return View();
        }
    }
}
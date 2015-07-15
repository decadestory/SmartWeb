using Sw.Base.Entity;
using Sw.Svc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SoulTraveller.Controllers
{
    public class SoulController : Controller
    {
        SoulerSvc svc = new SoulerSvc();

        // GET: Soul
        public ActionResult Index()
        {
            var list = svc.GetPage(1, 10);
            return View(list);
        }

        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(Souler souler)
        {
            var res = svc.Add(souler);
            return Json(new { data = res });
        }

    }
}
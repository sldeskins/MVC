using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RealEstateWithMongoDB_WOldDriver.Properties;

namespace RealEstateWithMongoDB_WOldDriver.Controllers
{
    public class HomeController : Controller
    {
        public RealEstateWithMongoDB_WOldDriver.App_Start.RealEstateContext Context = new App_Start.RealEstateContext();


        public ActionResult Index ()
        {
            //return View();
            Context.Database.GetStats();
             return Json(Context.Server.BuildInfo, JsonRequestBehavior.AllowGet);
        }

        public ActionResult About ()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact ()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
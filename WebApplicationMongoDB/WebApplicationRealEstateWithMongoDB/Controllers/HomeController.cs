using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplicationRealEstateWithMongoDB.Properties;

namespace WebApplicationRealEstateWithMongoDB.Controllers
{
    public class HomeController : Controller
    {
        public WebApplicationRealEstateWithMongoDB.App_Start.RealEstateContext Context = new App_Start.RealEstateContext();


        public ActionResult Index ()
        {
            return View();
            // return Json(Context.Server, JsonRequestBehavior.AllowGet);
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
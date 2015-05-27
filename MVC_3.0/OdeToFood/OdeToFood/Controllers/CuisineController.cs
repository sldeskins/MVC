using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OdeToFood.Infrastructure;

namespace OdeToFood.Controllers
{
    //[Authorize]
    //[Log]
    public class CuisineController : Controller
    {
        //
        // GET: /Cuisine/
        [HttpGet]
        public ActionResult Search(string name = "*")
        {

            if (name == "*")
            {
                return Json(new { name = "pete south" }, JsonRequestBehavior.AllowGet);
                // return File(Server.MapPath("~/Content/Site.css"), "text/css");
                //return RedirectToRoute("Cuisine", new { name = "german" });
                // return RedirectToAction("Search", "Cuisine",  new {name="french"});
            }
            name = Server.HtmlEncode(name);
            return Content(name);
        }

    }
}

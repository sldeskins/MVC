using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcIoC.Models;

namespace MvcIoC.Controllers
{
    public class ProteinTrackerController : Controller
    {
        private IProteinTrackingService protienTrackingService;

        // GET: ProteinTracking

        public ProteinTrackerController ( IProteinTrackingService protienTrackingService )
        {
           this. protienTrackingService = protienTrackingService;
        }

        public ActionResult Index()
        {
        ViewBag.Total = protienTrackingService.Total;
        ViewBag.Goal = protienTrackingService.Goal;
            return View();
        }
        public ActionResult AddProtein (int amount)
        {
            protienTrackingService.AddProtein(amount);
            ViewBag.Goal = protienTrackingService.Goal;
            return View("index");
        }
    }
}
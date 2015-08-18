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
    private ProtienTrackingService protienTrackingService = new ProtienTrackingService();

        // GET: ProteinTracking
        public ActionResult Index()
        {
        ViewBag.Total = protienTrackingService.Total;
        ViewBag.Goal = protienTrackingService.Goal;
            return View();
        }
        public ActionResult AddProtien (int amount)
        {
            protienTrackingService.AddProtien(amount);
            ViewBag.Goal = protienTrackingService.Goal;
            return View("index");
        }
    }
}
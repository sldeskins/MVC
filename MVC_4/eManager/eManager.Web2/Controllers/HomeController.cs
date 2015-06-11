﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using eManager.Domain;
using eManager.Web.Infrasturcture;


namespace eManager.Web.Controllers
{
    public class HomeController : Controller
    {
        private IDepartmentDataSource _db;
        public HomeController ( )
        {
            _db = new DepartmentDB();
        }
        public HomeController ( IDepartmentDataSource db )
        {
            _db = db;
        }
        public ActionResult Index ()
        {
            var allDepartments = _db.Departments;
            return View(allDepartments);
        }

        public ActionResult About ()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        public ActionResult Contact ()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}

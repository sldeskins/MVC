using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using eManager.Domain;
using eManager.Web.Infrasturcture;

namespace eManager.Web2.Controllers
{
    public class DepartmentController : Controller
    {
        private IDepartmentDataSource _db;
        public DepartmentController ()
        {
            _db = new DepartmentDB();
        }
        public DepartmentController ( IDepartmentDataSource db )
        {
            _db = db;
        }
        public ActionResult Detail ( int id )
        {
            var model = _db.Departments.Single(d => d.ID == id);
            return View(model);
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using eManager.Web2.Models;
using eManager.Domain;
using eManager.Web.Infrasturcture;

namespace eManager.Web2.Controllers
{
    public class EmployeeController : Controller
    {  private IDepartmentDataSource _db;
        public EmployeeController ()
        {
            _db = new DepartmentDB();
        }
        public EmployeeController ( IDepartmentDataSource db )
        {
            _db = db;
        }
        [HttpGet]
        public ActionResult Create(int departmentId)
        {
            var model = new CreateEmployeeViewModel();
            model.DepartmentId = departmentId;
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create ( CreateEmployeeViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var department = _db.Departments.Single(d => d.ID == viewModel.DepartmentId);
                var employee = new Employee();
                employee.Name = viewModel.Name;
                employee.HireDate = viewModel.HireDate;
                department.Employees.Add(employee);
                _db.Save();
                 return RedirectToAction("detail","department", new{id=viewModel.DepartmentId});
            }
            return View(viewModel);
        }
    }
}

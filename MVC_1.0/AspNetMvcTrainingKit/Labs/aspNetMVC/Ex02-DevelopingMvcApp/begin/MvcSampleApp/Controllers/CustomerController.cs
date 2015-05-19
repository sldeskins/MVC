using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcSampleApp.Models;
using MvcSampleApp.ViewData;

namespace MvcSampleApp.Controllers
{
    public class CustomerController : Controller
    {
        private AdventureWorksRepository repository = new AdventureWorksRepository();
        //
        // GET: /Customer/

        public ActionResult Index(int? page)
        {
            var viewData = new CustomerViewData();
            int currentPage = page ?? 0;
            viewData.Customers = this.repository.GetCustomers(currentPage, 10);
            viewData.NextPage = currentPage + 1;
            viewData.PreviousPage = (currentPage <= 0) ? 0 : currentPage - 1;
            return View(viewData);
        }
        public ActionResult Info(int id)
        {
            var customer = this.repository.GetCustomerById(id);
            return View(customer);
        }
    }
}

// ----------------------------------------------------------------------------------
// Microsoft Developer & Platform Evangelism
// 
// Copyright (c) Microsoft Corporation. All rights reserved.
// 
// THIS CODE AND INFORMATION ARE PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
// EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED WARRANTIES 
// OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
// ----------------------------------------------------------------------------------
// The example companies, organizations, products, domain names,
// e-mail addresses, logos, people, places, and events depicted
// herein are fictitious.  No association with any real company,
// organization, product, domain name, email address, logo, person,
// places, or events is intended or should be inferred.
// ----------------------------------------------------------------------------------

namespace MvcSampleApp.Controllers
{
    using System.Web.Mvc;
    using MvcSampleApp.Models;
    using MvcSampleApp.ViewData;

    public class CustomerController : Controller
    {
        private AdventureWorksRepository repository = new AdventureWorksRepository();

        //
        // GET: /Customer/

        public ActionResult Index()
        {
            var viewData = new CustomerViewData();
            viewData.Customers = this.repository.GetCustomers(0, 10);
            viewData.NextPage = 1;
            viewData.PreviousPage = 0;
            return View(viewData);
        }

        public ActionResult Info(int id)
        {
            var customer = this.repository.GetCustomerById(id);
            return View(customer);
        }

        public ActionResult FilterCustomers(string customersFilter)
        {
            var viewData = new CustomerViewData();
            viewData.Customers = this.repository.GetFilteredCustomers(customersFilter, 0, 10);
            viewData.NextPage = 1;
            viewData.PreviousPage = 0;
            viewData.CustomerFilter = customersFilter;
            return PartialView("CustomerList", viewData);
        }

        public ActionResult ChangeCustomersPage(string customersFilter, int currentPage)
        {
            var viewData = new CustomerViewData();
            if (string.IsNullOrEmpty(customersFilter))
            {
                viewData.Customers = this.repository.GetCustomers(currentPage, 10);
            }
            else
            {
                viewData.Customers = this.repository.GetFilteredCustomers(customersFilter, currentPage, 10);
            }

            viewData.NextPage = currentPage + 1;
            viewData.PreviousPage = (currentPage <= 0) ? 0 : currentPage - 1;
            viewData.CustomerFilter = customersFilter;
            return PartialView("CustomerList", viewData);
        }
    }
}
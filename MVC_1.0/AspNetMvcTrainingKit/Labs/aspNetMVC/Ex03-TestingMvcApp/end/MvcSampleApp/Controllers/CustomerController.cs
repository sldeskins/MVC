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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using MvcSampleApp.Models;
using MvcSampleApp.ViewData;

namespace MvcSampleApp.Controllers
{
    public class CustomerController : Controller
    {
        // private AdventureWorksRepository repository = new AdventureWorksRepository();
        private IAdventureWorksRepository repository;

        public CustomerController()
        {
            this.repository = new AdventureWorksRepository();
        }

        public CustomerController(IAdventureWorksRepository repository)
        {
            this.repository = repository;
        }

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
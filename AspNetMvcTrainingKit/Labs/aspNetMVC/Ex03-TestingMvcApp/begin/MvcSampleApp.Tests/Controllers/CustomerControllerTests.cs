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

namespace MvcSampleApp.Tests
{
    using System.Linq;
    using System.Web.Mvc;
    using MvcSampleApp.Models;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using MvcSampleApp.Controllers;
    using MvcSampleApp.ViewData;

    [TestClass]
    public class CustomerControllerTests
    {
        [TestMethod]
        public void ShouldLoadCustomerIndexView()
        {
            CustomerController controller = new CustomerController(new AdventureWorksRepositoryStub());
            ViewResult result = controller.Index(1) as ViewResult;

            Assert.IsTrue(string.IsNullOrEmpty(result.ViewName));
            Assert.IsNotNull(result.ViewData);
        }

        [TestMethod]
        public void ShouldLoadCustomerIndexPageView()
        {
            CustomerController controller = new CustomerController(new AdventureWorksRepositoryStub());
            ViewResult result = controller.Index(1) as ViewResult;

            Assert.IsInstanceOfType(result.ViewData.Model, typeof(CustomerViewData));
            CustomerViewData customerViewData = result.ViewData.Model as CustomerViewData;
            Assert.AreEqual(2, customerViewData.NextPage, "Page 2 expected");
            Assert.AreEqual(2, customerViewData.Customers.Count(), "2 Customers expected");
        }

        [TestMethod]
        public void ShouldLoadCustomerInfoView()
        {
            CustomerController controller = new CustomerController(new AdventureWorksRepositoryStub());
            ViewResult result = controller.Info(1) as ViewResult;

            Assert.IsTrue(string.IsNullOrEmpty(result.ViewName));
            Assert.IsNotNull(result.ViewData);
        }

        [TestMethod]
        public void ShouldLoadCustomerOneInfoView()
        {
            CustomerController controller = new CustomerController(new AdventureWorksRepositoryStub());
            ViewResult result = controller.Info(1) as ViewResult;

            Assert.IsInstanceOfType(result.ViewData.Model, typeof(Customer));
            Customer customer = result.ViewData.Model as Customer;
            Assert.AreEqual(1, customer.CustomerID, "CustomerId 1 expected");

        }
    }
}
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
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MvcSampleApp.Controllers;
using System.Web.Mvc;
using MvcSampleApp.Models;
using MvcSampleApp.ViewData;

namespace MvcSampleApp.Tests.Controllers
{
    /// <summary>
    /// Summary description for ProductControllerTest
    /// </summary>
    [TestClass]
    public class ProductControllerTest
    {
        
        [TestMethod]
        public void ShouldLoadProductIndexView()
        {
            ProductController controller = new ProductController(new AdventureWorksRepositoryStub());
            ViewResult result = controller.Index(1) as ViewResult;

            Assert.IsInstanceOfType(result.ViewData.Model, typeof(ProductViewData));
            ProductViewData productViewData = result.ViewData.Model as ProductViewData;
            Assert.AreEqual(2, productViewData.NextPage, "Page 2 expected");
            Assert.AreEqual(2, productViewData.Products.Count(), "2 Products expected");
        }

        [TestMethod]
        public void ShouldLoadProductDetailsView()
        {
            ProductController controller = new ProductController(new AdventureWorksRepositoryStub());
            ViewResult result = controller.Details(609) as ViewResult;

            Assert.IsInstanceOfType(result.ViewData.Model, typeof(Product));
            Product product = result.ViewData.Model as Product;
            Assert.AreEqual(609, product.ProductID, "Product Id 609 expected");
        }

        [TestMethod]
        public void ShouldLoadProductCreateView()
        {
            throw new NotImplementedException();
        }

        [TestMethod]
        public void ShouldLoadProductEditView()
        {
            throw new NotImplementedException();
        }

        


    }
}
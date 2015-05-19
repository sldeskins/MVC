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
    using System;
    using System.Web;
    using System.Web.Routing;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using MvcSampleApp;

    [TestClass]
    public class RouteTests
    {
        public RouteTests()
        {
        }

        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }        

        [TestMethod]
        public void ShouldCustomerTakeDefaultRoute()
        {
           //TODO: Place code here
        }

        [TestMethod]
        public void ShouldCustomerTakeInfoRoute()
        {
           //TODO: Place code here
        }

        [TestMethod]
        public void ShouldAddressTakeCreateRoute()
        {
           //TODO: Place code here
        }

        private static RouteData GetRouteDataForUrl(RouteCollection routes, string url)
        {
            //TODO: Place code here (replacing the the existing code)
            return null;
        }
    }
}
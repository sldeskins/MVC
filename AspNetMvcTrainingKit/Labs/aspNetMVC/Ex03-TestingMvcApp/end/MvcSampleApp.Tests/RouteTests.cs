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
    using Moq;

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
            RouteCollection routes = new RouteCollection();
            MvcApplication.RegisterRoutes(routes);

            RouteData routeData = GetRouteDataForUrl(routes, "~/Customer");

            Assert.IsNotNull(routeData, "Should have found the route");
            Assert.AreEqual("Customer", routeData.Values["controller"], "Customer controller expected");
            Assert.AreEqual("Index", routeData.Values["action"], "Index action expected");
        }

        [TestMethod]
        public void ShouldCustomerTakeInfoRoute()
        {
            RouteCollection routes = new RouteCollection();
            MvcApplication.RegisterRoutes(routes);

            RouteData routeData = GetRouteDataForUrl(routes, "~/Customer/Info/1");

            Assert.IsNotNull(routeData, "Should have found the route");
            Assert.AreEqual("Customer", routeData.Values["controller"], "Customer controller expected");
            Assert.AreEqual("1", routeData.Values["id"], "Customer ID = 1 expected");
            Assert.AreEqual("Info", routeData.Values["action"], "Info action expected");
        }

        [TestMethod]
        public void ShouldAddressTakeCreateRoute()
        {
            RouteCollection routes = new RouteCollection();
            MvcApplication.RegisterRoutes(routes);

            RouteData routeData = GetRouteDataForUrl(routes, "~/Address/Create/1");

            Assert.IsNotNull(routeData, "Should have found the route");
            Assert.AreEqual("Address", routeData.Values["Controller"], "Address controller expected");
            Assert.AreEqual("1", routeData.Values["Id"], "Customer ID = 1 expected");
            Assert.AreEqual("Create", routeData.Values["action"], "Create action expected");
        }

        private static RouteData GetRouteDataForUrl(RouteCollection routes, string url)
        {
            var mockRequest = new Mock<HttpRequestBase>();
            mockRequest.Setup(r => r.AppRelativeCurrentExecutionFilePath).Returns(url);
            mockRequest.Setup(r => r.PathInfo).Returns(String.Empty);

            var mockContext = new Mock<HttpContextBase>();
            mockContext.Setup(c => c.Request).Returns(mockRequest.Object);

            RouteData routeData = routes.GetRouteData(mockContext.Object);
            return routeData;
        }
    }
}
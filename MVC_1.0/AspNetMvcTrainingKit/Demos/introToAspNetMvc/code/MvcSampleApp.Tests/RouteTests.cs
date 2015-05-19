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
        [TestMethod]
        public void ShouldProductTakeDefaultRoute()
        {
            RouteCollection routes = new RouteCollection();
            MvcApplication.RegisterRoutes(routes);

            RouteData routeData = GetRouteDataForUrl(routes, "~/Product");

            Assert.IsNotNull(routeData, "Should have found the route");
            Assert.AreEqual("Product", routeData.Values["controller"], "Product controller expected");
            Assert.AreEqual("Index", routeData.Values["action"], "Index action expected");
        }

        [TestMethod]
        public void ShouldProductTakeInfoRoute()
        {
            RouteCollection routes = new RouteCollection();
            MvcApplication.RegisterRoutes(routes);

            RouteData routeData = GetRouteDataForUrl(routes, "~/Product/Info/1");

            Assert.IsNotNull(routeData, "Should have found the route");
            Assert.AreEqual("Product", routeData.Values["controller"], "Product controller expected");
            Assert.AreEqual("1", routeData.Values["id"], "Product ID = 1 expected");
            Assert.AreEqual("Info", routeData.Values["action"], "Info action expected");
        }

        [TestMethod]
        public void ShouldProductTakeCreateRoute()
        {
            RouteCollection routes = new RouteCollection();
            MvcApplication.RegisterRoutes(routes);

            RouteData routeData = GetRouteDataForUrl(routes, "~/Product/Create/1");

            Assert.IsNotNull(routeData, "Should have found the route");
            Assert.AreEqual("Product", routeData.Values["Controller"], "Product controller expected");
            Assert.AreEqual("1", routeData.Values["Id"], "Product ID = 1 expected");
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
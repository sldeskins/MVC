using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Commerce.MVC.Controllers;
using System.Web.Mvc;

namespace Commerce.MVC.Tests
{
    [TestClass]
    public class CatalogControllerTests
    {
        [TestMethod]
        public void CatalogController_ShouldContain_indexMethod() {
            CatalogController c = new CatalogController();
            ActionResult result = c.Index("", "");
            Assert.IsNotNull(result);
        }
    }
}

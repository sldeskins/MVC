using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MvcIoC.Controllers;
using System.Web.Mvc;

namespace MvcIoC.Tests.Controllers
{
    [TestClass]
    public class ProteinTrackerControllerTest
    {
        [TestMethod]
        public void WhenNothingHappensTotalAndGoalAreZero ()
        {
            ProteinTrackerController controller = new ProteinTrackerController();
         
            ViewResult result = controller.Index() as ViewResult;

            Assert.AreEqual(0, result.ViewBag.Total);
            Assert.AreEqual(0, result.ViewBag.Goal);
        }
    }
}

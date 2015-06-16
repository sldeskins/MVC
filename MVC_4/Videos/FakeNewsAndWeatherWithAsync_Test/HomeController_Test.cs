using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FakeNewsAndWeatherWithAsync.Controllers;
using System.Web.Mvc;
using FakeNewsAndWeatherWithAsync;
using System.Threading.Tasks;

namespace AysncAwait.Test.Controllers
{
    [TestClass]
    public class HomeController_Test
    {
        [TestMethod]
        public async Task Index_Produces_model ()
        {
            var controller = new HomeController();
            var result = (ViewResult) await controller.Index();
            var model = result.Model;

            Assert.IsNotNull(model as HomePageViewModel);
        }
    }
}

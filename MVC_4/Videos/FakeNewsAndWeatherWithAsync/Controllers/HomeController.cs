using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FakeNewsAndWeatherWithAsync;
using System.Threading.Tasks;
using System.Threading;

namespace FakeNewsAndWeatherWithAsync.Controllers
{
    public class HomeController : Controller
    {
        [AsyncTimeout(3200)]
        [HandleError(ExceptionType=typeof(TimeoutException), View="Timeout")]
        public async Task<ActionResult> IndexWithCancellation (CancellationToken ctk)
        {
            var model = new HomePageViewModel();
        
            
            model.AddMessage("Starting action");

            var headlineTask = GetHeadlineAsync(model);// var headlineTask = GetHeadlineAsync(model, ctk);
            var temperatureTask = GetCurrentTemperatureAsync(model);

            await Task.WhenAll(headlineTask, temperatureTask);

            model.AddMessage("Finished Action");
            return View(model);
        }

        public async Task<ActionResult> Index ()
        {
            var model = new HomePageViewModel();


            model.AddMessage("Starting action");

            var headlineTask = GetHeadlineAsync(model);
            var temperatureTask = GetCurrentTemperatureAsync(model);

            await Task.WhenAll(headlineTask, temperatureTask);

            model.AddMessage("Finished Action");
            return View(model);
        }
        async Task GetCurrentTemperatureAsync ( HomePageViewModel model )
        {
            model.AddMessage("Starting weather");
            var weatherClient = new WeatherServiceClient();
            //todo make wpf service for Weather Client 
            model.Temperature = await weatherClient.GetCurrentTemperatureAsync();

            throw new Exception("Thermometer broken!");

            model.AddMessage("Finished weather");
        }
        async Task GetHeadlineAsync ( HomePageViewModel model )
        {
            model.AddMessage("Starting news");
            var newsClient = new NewsServiceClient();
            //todo make wpf service for NewsServiceClient
            model.Headline = await newsClient.GetHeadlineAsync();
            
            throw new Exception("No News!");

            model.AddMessage("Finished news");
        }
        public ActionResult About ()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        public ActionResult Contact ()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}

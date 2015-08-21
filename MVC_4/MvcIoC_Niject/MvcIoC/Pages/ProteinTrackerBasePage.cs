using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcIoC.Models;
using Ninject;

namespace MvcIoC.Pages
{
    public class ProteinTrackerBasePage : WebViewPage
    {
        [Inject]
        public IAnalyticsService AnalyticsService { get; set; }

        public override void Execute ()
        {
        }

    }
}
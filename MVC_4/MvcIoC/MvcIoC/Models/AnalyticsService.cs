using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcIoC.Models
{
    public class AnalyticsService : IAnalyticsService
    {
        public string Code { get { return "Tracking you!"; } }
    }
}
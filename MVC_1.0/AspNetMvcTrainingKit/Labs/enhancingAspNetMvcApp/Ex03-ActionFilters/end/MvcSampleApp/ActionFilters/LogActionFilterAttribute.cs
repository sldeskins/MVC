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

namespace MvcSampleApp.ActionFilters
{
    using System.Diagnostics;
    using System.Globalization;
    using System.Web.Mvc;
    using System.Web.Routing;

    public sealed class LogActionFilterAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            LogEntry("Executing", filterContext.RouteData);
        }

        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            LogEntry("Executed", filterContext.RouteData);
        }

        private static void LogEntry(string executionStep, RouteData routeData)
        {
            string controller = routeData.Values["controller"] as string;
            string action = routeData.Values["action"] as string;
            string entry = string.Format(CultureInfo.CurrentUICulture, "Log Action Filter: {0} {1} on {2}", executionStep, action, controller);
            
            Debug.WriteLine(entry);
        }
    }
}
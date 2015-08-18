using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MvcIoC.Models;
using System.Web.Mvc;
using MvcIoC.Controllers;
using System.Web.Routing;
using System.Web.SessionState;

namespace MvcIoC 
{
    public class CustomeControllerFactory : IControllerFactory
    {
        public IController CreateController ( RequestContext requestContext, string controllerName )
        {
            if (controllerName.ToLower().StartsWith("proteintracker"))
            {
                var service = new ProteinTrackingService();
                var controller = new ProteinTrackerController(service);
                return controller;
            }

            var defaultFactory = new DefaultControllerFactory();
            return defaultFactory.CreateController(requestContext, controllerName);
        }

        public SessionStateBehavior GetControllerSessionBehavior ( System.Web.Routing.RequestContext requestContext, string controllerName )
        {
            return SessionStateBehavior.Default;
        }

        public void ReleaseController ( IController controller )
        {
            var disposable = controller as IDisposable;
            if (disposable != null)
            {
                disposable.Dispose();
            }
        }
    }
}
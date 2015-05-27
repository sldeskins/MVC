using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcMovie.Controllers
{
    public class HelloWorldController : Controller
    {
        // GET: HelloWorld
        public ContentResult Index ()
        {
            return new ContentResult()
             {
                 Content = "This is my <b>default</b> action..."
             };
        }
        public ContentResult Welcome ()
        {
            return new ContentResult()
            {
                Content = "This is the Welcome action method..."
            };
        }
    }
}
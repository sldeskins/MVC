using System;
using System.Web;
using System.Web.Mvc;
using System.Collections.Generic;
using MvcSampleApp.Models;

namespace MvcSampleApp.ViewData
{
    public class CustomerViewData
    {
        public IEnumerable<Customer> Customers
        {
            get;
            set;
        }

        public int PreviousPage
        {
            get;
            set;
        }

        public int NextPage
        {
            get;
            set;
        }
    }
}
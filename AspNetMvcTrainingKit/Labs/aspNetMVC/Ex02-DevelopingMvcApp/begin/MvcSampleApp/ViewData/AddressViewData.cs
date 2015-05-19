using System;
using System.Web;
using System.Web.Mvc;
using MvcSampleApp.Models;

namespace MvcSampleApp.ViewData
{
    public class AddressViewData
    {
        public Address Address
        {
            get;
            set;
        }

        public int CustomerId
        {
            get;
            set;
        }

    }
}
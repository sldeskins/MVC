﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplicationRealEstateWithMongoDB.Rentals
{
    public class AdjustPrice
    {
        public decimal NewPrice
        {
            get;
            set;
        }
        public string Reason
        {
            get;
            set;
        }
    }
}
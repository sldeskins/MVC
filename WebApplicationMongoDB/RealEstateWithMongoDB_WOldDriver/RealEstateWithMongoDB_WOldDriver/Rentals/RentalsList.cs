﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RealEstateWithMongoDB_WOldDriver.Rentals
{
    public class RentalsList
    {
        public IEnumerable<Rental> Rentals
        {
            get;
            set;
        }
        public RentalsFilter Filters
        {
            get;
            set;
        }
    }
    
}
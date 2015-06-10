using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RealEstateWithMongoDB_WOldDriver.Rentals
{
    public class RentalsFilter
    {
        public decimal? PriceLimit
        {
            get;
            set;
        }
        public int? MinimunRooms
        {
            get;
            set;
        }
    }
}
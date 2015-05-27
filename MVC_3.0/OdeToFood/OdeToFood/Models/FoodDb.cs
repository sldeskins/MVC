using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OdeToFood.Models
{
    public class FoodDb
    {
        static List<RestaurantReview> _reviews;
        static List<RestaurantReview> Reviews { get { return _reviews; } }
        static FoodDb()
        {
            _reviews = new List<RestaurantReview>();
            _reviews.Add(new RestaurantReview { Rating = 8, Name = "Rae" });
            _reviews.Add(new RestaurantReview { Rating = 7, Name = "Charles" });
            _reviews.Add(new RestaurantReview { Rating = 8, Name = "The Supper Club" });
        }
    }
}

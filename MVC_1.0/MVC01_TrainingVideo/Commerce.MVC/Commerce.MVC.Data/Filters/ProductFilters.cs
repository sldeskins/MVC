using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Commerce.MVC.Data 
{
    public static class ProductFilters
    {
        public static IQueryable<Product> WithCategory(this IQueryable<Product> qry, int categoryID)
        {
            return from p in qry
                   where p.CategoryID == categoryID
                   select p;
        }
        public static IQueryable<Product> WithID(this IQueryable<Product> qry, int ID)
        {
            return from p in qry
                   where p.ID == ID
                   select p;
  
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Commerce.MVC.Data;
using Commerce.MVC.Data.DataAccess;

namespace Commerce.MVC.Tests
{
    public class TestCatalogRepository : ICatalogRepository
    {
        public IQueryable<Category> GetCategories()
        {
            IList<Category> result = new List<Category>();

            for (int i = 1; i <= 2; i++)
            {
                Category c = new Category();
                c.ID = 1;
                c.Name = "Parent" + i.ToString();
                c.ParentID = 0;
                result.Add(c);

                for (int x = 10; x < 15; x++)
                {
                    Category sub = new Category();
                    sub.ID = x;
                    sub.Name = "Sub" + x.ToString();
                    sub.ParentID = i;
                    result.Add(sub);
                }

            }
            return result.AsQueryable<Category>();

        }
    }
}

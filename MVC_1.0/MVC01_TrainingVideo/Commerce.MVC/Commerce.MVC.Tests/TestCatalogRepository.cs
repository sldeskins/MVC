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
        IList<Product> productList;
        IList<Category> categoryList;

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
        public IQueryable<Product> GetProducts()
        {
            IList<Product> result = new List<Product>();

            int loopIndex = 0;
            int uniqueProductID = 1;

            var categories = GetCategories().Where(x => x.ParentID > 0).ToList();

            foreach (var c in categories)
            {
                for (int y = 1; y <= 5; y++)
                {
                    Product p = new Product();
                    p.Name = "Product" + loopIndex.ToString();
                    p.ID = uniqueProductID;
                    p.Price = y * 5.68M;
                    p.Description = "Test Description";

                    p.CategoryID = c.ID;
                    uniqueProductID++;
                    result.Add(p);
                }
            }

            return result.AsQueryable<Product>();
        }


    }
}

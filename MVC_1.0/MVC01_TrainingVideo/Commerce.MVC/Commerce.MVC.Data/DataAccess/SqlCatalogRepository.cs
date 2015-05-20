using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Commerce.MVC.SqlRepository;
using Commerce.MVC.Data;

namespace Commerce.MVC.Data.DataAccess
{
    public class SqlCatalogRepository : ICatalogRepository
    {
        #region ICatalogRepository Members

        public IQueryable<Category> GetCategories()
        {
            DBDataContext ctx = new DBDataContext();

            return from c in ctx.Categories
                   select new Category
                   {
                       ID = c.CategoryID,
                       Name = c.CategoryName,
                       ParentID = c.ParentID ?? 0
                   };
        }

        public IQueryable<Product> GetProducts()
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}

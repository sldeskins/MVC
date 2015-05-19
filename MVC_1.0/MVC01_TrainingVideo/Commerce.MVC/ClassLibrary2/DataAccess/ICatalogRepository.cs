using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Commerce.MVC.Data.DataAccess
{
    public interface ICatalogRepository
    {
        IQueryable<Category> GetCategories();
    }
}

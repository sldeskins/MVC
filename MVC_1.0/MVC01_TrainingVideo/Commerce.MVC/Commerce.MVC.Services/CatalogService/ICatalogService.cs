using System;
using System.Collections.Generic;
using Commerce.MVC.Data;

namespace Commerce.MVC.Services
{
    public interface ICatalogService
    {
        IList<Commerce.MVC.Data.Category> GetCategories();
        Category GetCategory(int id);
        Category GetDefaultCategory();
        Product GetProduct(string productCode);
        Product GetProduct(int id);
        IList<Commerce.MVC.Data.Product> GetProductsByCategory(int categoryID);
        IList<Commerce.MVC.Data.Product> GetRelatedProducts(int productID);
        IList<Commerce.MVC.Data.Product> GetCrossProducts(int productID);
        void SaveProduct(Product p);
    }
}

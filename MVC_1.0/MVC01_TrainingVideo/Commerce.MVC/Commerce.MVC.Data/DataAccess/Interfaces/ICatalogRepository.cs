using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Commerce.MVC.Data
{

    public interface ICatalogRepository
    {

        IQueryable<Category> GetCategories();
        IQueryable<Product> GetProducts();
        IQueryable<ProductReview> GetReviews();
        IQueryable<ProductImage> GetProductImages();
        IQueryable<ProductCategoryMap> GetProductCategoryMap();
        IQueryable<ProductRelatedMap> GetRelatedProductMap();
        IQueryable<ProductCrossSellMap> GetCrossSellProductMap();

        void SaveProduct(Product product);

    }
}

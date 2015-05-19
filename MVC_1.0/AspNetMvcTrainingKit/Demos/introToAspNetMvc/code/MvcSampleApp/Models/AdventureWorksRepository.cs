// ----------------------------------------------------------------------------------
// Microsoft Developer & Platform Evangelism
// 
// Copyright (c) Microsoft Corporation. All rights reserved.
// 
// THIS CODE AND INFORMATION ARE PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
// EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED WARRANTIES 
// OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
// ----------------------------------------------------------------------------------
// The example companies, organizations, products, domain names,
// e-mail addresses, logos, people, places, and events depicted
// herein are fictitious.  No association with any real company,
// organization, product, domain name, email address, logo, person,
// places, or events is intended or should be inferred.
// ----------------------------------------------------------------------------------

namespace MvcSampleApp.Models
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using System.Web.Mvc;

    public class AdventureWorksRepository:IAdventureWorksRepository
    {
        AdventureWorksLTEntities context = new AdventureWorksLTEntities();

        public IEnumerable<Product> GetProducts(int page, int size)
        {
            return context.Product.OrderBy(p => p.ProductID).Skip(page * size).Take(size);
        }

            public void AddProduct(Product product)
        {
            product.rowguid = Guid.NewGuid();
            product.ModifiedDate = DateTime.Now;
            context.AddObject("Product", product);
            context.SaveChanges();
        }

        public void UpdateProduct()
        {
            context.SaveChanges();
        }

        public void DeleteProduct(Product product)
        {
            context.DeleteObject(product);
            context.SaveChanges();
        }

        public Product GetProductById(int productId)
        {
            return context.Product.Where(p => p.ProductID == productId).First();
        }


    }
}
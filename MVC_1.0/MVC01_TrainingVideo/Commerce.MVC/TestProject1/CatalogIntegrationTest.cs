using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Commerce.MVC.SqlRepository.Data;
using Commerce.MVC.SqlRepository;
using Commerce.MVC.Data; 
using Commerce.MVC.Services;

namespace Commerce.MVC.IntegrationTests
{
    [TestClass]
    public class CatalogIntegrationTest
    {
        [TestMethod]
        public void SqlCatalogRespository_ShouldReturn_Categories_AsQuerable_()
        {
            SqlCatalogRepository rep = new SqlCatalogRepository();
        
            IQueryable<Category> qry = rep.GetCategories();
            Assert.IsNotNull(qry);

            IList<Category> catList = (from c in qry
                                       where c.ID == 1
                                       select c).ToList<Category>();

            Assert.AreEqual(1, catList.Count);
            Assert.AreEqual("category1", catList[0].Name);
        }

    }
}

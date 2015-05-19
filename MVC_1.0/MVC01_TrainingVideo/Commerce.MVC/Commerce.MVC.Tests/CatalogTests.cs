using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Commerce.MVC.Data;
using Commerce.MVC.Data.DataAccess;
using Commerce.MVC.Services;

namespace Commerce.MVC.Tests
{
    [TestClass]
    public class CatalogTests
    {
        CatalogServices catalogService;
        [TestInitialize]
        public void SetUp()
        {
            ICatalogRepository rep = new TestCatalogRepository();
            catalogService = new CatalogServices(rep);
        }

        #region Product Tests

        [TestMethod]
        public void Product_Discount_Amount_Is_Valid()
        {
            Product p = new Product();
            p.ListPrice = 100;
            p.DiscountPercent = 40;
            Assert.AreEqual(40, p.DiscountAmount);
        }
        [TestMethod]
        public void Product_Discount_Price_Is_Valid()
        {
            Product p = new Product();
            p.ListPrice = 100;
            p.DiscountPercent = 40;
            Assert.AreEqual(60, p.DiscountPrice);
        }
        #endregion

        [TestMethod]
        public void CatalogRespository_Respository_IsNotNull()
        {
            ICatalogRepository rep = new TestCatalogRepository();
            Assert.IsNotNull(rep.GetCategories());
        }
        [TestMethod]
        public void CatalogService_Can_Get_Categories_From_Service()
        {
            IList<Category> categories = catalogService.GetCatergories();
            Assert.IsTrue(categories.Count > 0);
        }
        [TestMethod]
        public void CatalogService_Can_Group_ParentCategories()
        {
            IList<Category> categories = catalogService.GetCatergories();
            Assert.AreEqual(2, categories.Count);
        }
        [TestMethod]
        public void CatalogService_Can_Group_SubCategories()
        {
            IList<Category> categories = catalogService.GetCatergories();
            Assert.AreEqual(5, categories[0].SubCategories.Count);
        }
    }
}

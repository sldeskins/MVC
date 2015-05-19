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

        #region Category Tests

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
        #endregion

        #region Product Tests

        [TestMethod]
        public void Product_ShouldHave_Name_Description_Category_Price_Discount_Fields()
        {
            Product p = new Product("TestName", "TestDescription", 10, 100, 20);
            Assert.AreEqual("TestName", p.Name);
            Assert.AreEqual("TestDescription", p.Description);
            Assert.AreEqual(10, p.CategoryID);
            Assert.AreEqual(20, p.DiscountPercent);
            Assert.AreEqual(100, p.Price);
        }
        [TestMethod]
        public void CatalogRepository_Contains_Products()
        {
            ICatalogRepository rep = new TestCatalogRepository();
            Assert.IsNotNull(rep.GetProducts());
        }
        [TestMethod]
        public void CatalogRepository_Each_Category_Contain_5_Products()
        {
            ICatalogRepository rep = new TestCatalogRepository();
            var categories = rep.GetCategories().Where(c => c.ParentID != 0).ToList();
            var products = rep.GetProducts().ToList();

            foreach (Category c in categories)
            {
                int productCount = (from p in products
                                    where p.CategoryID == c.ID
                                    select p).Count();
                Assert.AreEqual(5, productCount);
            }
            Assert.IsNotNull(rep.GetProducts());
        }
        [TestMethod]
        public void Repository_has_Category_Filter_For_Products()
        {
            ICatalogRepository rep = new TestCatalogRepository();
            IList<Product> products = rep.GetProducts()
                .WithCategory(11)
                .ToList();
            Assert.IsNotNull(products);
        }
        [TestMethod]
        public void Repository_ProductFilter_Returns_5_Products_Wtih_Category_11()
        {
            ICatalogRepository rep = new TestCatalogRepository();
            IList<Product> products = rep.GetProducts().WithCategory(11).ToList();
            Assert.AreEqual(5, products.Count);

        }
        [TestMethod]
        public void CatalogService_Returns_5_Products_Wtih_Category_11()
        {
            IList<Product> products = catalogService.GetProductsByCategory(11).ToList();
            Assert.AreEqual(5, products.Count);
        }
        [TestMethod]
        public void Repository_Returns_Single_Product_When_Filtered_ByID_1()
        {
            ICatalogRepository rep = new TestCatalogRepository();
            IList<Product> products = rep.GetProducts().WithID(1).ToList();
            Assert.AreEqual(1, products.Count);
        }
        [TestMethod]
        public void Service_Returns_Single_Product_When_Filtered_ByID_1()
        {
          Product p = catalogService.GetProductsByID(1);
          Assert.IsNotNull(p);
        }
        #endregion
    }
}

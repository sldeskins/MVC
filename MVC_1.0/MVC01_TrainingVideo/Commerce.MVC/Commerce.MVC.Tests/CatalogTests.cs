using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Commerce.MVC.Data;

namespace Commerce.MVC.Tests
{
    [TestClass]
    public class CatalogTests
    {
        [TestMethod]
        public void Product_Discount_Amount_Is_Valid()
        {
            Product p = new Product();
            p.ListPrice = 100;
            p.DiscountPercent = 40;
            Assert.AreEqual(40,p.DiscountAmount);
        }
        [TestMethod]
        public void Product_Discount_Price_Is_Valid()
        {
            Product p = new Product();
            p.ListPrice = 100;
            p.DiscountPercent = 40;
            Assert.AreEqual(60, p.DiscountPrice);
        }
    }
}

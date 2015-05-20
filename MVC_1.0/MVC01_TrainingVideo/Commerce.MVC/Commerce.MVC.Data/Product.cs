using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Commerce.MVC.Data
{
    public class Product
    {
        public int ID { get; set; }
        public int CategoryID { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }

        public decimal Price { get; set; }

        public string SummaryDescription { get; set; }
        public string ThumbnailFileName { get; set; }
        public string LargePhotoFileName { get; set; }
        public decimal ListPrice { get; set; }
        public decimal DiscountPercent { get; set; }

        public decimal DiscountAmount
        {
            get
            {
                decimal result = 0;
                if (this.DiscountPercent > 00 && this.ListPrice > 0)
                {
                    decimal discountRate = this.DiscountPercent * .01M;
                    result = this.ListPrice * discountRate;
                }

                return result;
            }
        }
        public decimal DiscountPrice
        {
            get
            {
                return this.ListPrice - this.DiscountAmount;
            }
        }

        public Product()
        {

        }
        public Product(string name, string description, int categoryID, decimal price, decimal discountPercent)
        {
            this.Name = name;
            this.Description = description;
            this.DiscountPercent = discountPercent;
            this.CategoryID = categoryID;
            this.Price = price;

        }
    }
}

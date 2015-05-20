using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Commerce.MVC.Data
{
    public class ProductDescription
    {
        public String Body { get; set; }
        public int ID { get; set; }
        public string Locale { get; set; }
        public int ProductID { get; set; }

        public ProductDescription()
        {

        }
    }
}

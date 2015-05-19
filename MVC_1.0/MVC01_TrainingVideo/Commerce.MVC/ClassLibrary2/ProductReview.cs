using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Commerce.MVC.Data
{
    public class ProductReview
    {
        public int ID { get; set; }
        public int ProductID { get; set; }
        public DateTime ReviewDate { get; set; }
        public string ReviewBody { get; set; }
        public string AuthorName { get; set; }
        public string AuthorEmail { get; set; }
    }
}

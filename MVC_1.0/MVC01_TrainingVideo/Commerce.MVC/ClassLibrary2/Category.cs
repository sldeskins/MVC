using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Commerce.MVC.Data
{
    public class Category
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int ParentID { get; set; }
        public List<Category> SubCategories { get; set; }
    }
}

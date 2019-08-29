using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MagicLight.Products.Model
{
    public class Product
    {
        public int Id { get; set; }
        public string Category { get; set; }
        public string SubCategoryName { get; set; }
        public string SubSubCategoryName { get; set; }
        public string Url { get; set; }
        public string ProductImageLink { get; set; }
        public string Description { get; set; }
        public string ProductNumber { get; set; }
        public string Categorija { get; set; }
        public string Pavadinimas { get; set; }
        public string Apibudinimas { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DilekSaylan.WepApiDemo.Models
{
    public class ProductModel
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal UnitPrice { get; set; }
        public string CategoryName { get; set; } //product and category table join
    }
}

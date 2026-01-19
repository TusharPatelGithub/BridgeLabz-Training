using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flash_Deals
{
    class Product
    {
        public int productId { get; set; }
        public string productName { get; set; }
        public double discount { get; set; }
        public override string ToString()
        {
            return $"ID: {productId}, Name: {productName}, Discount: {discount}%";
        }
    }
}
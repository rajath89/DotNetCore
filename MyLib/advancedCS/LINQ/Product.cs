using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLib.advancedCS.LINQ
{
    public class Product
    {
        public string ProductId { get; set; }
        public string ProductName { get; set; }
        public double Price { get; set; }
        public int QuantityAvailable { get; set; }
        public int CategoryId { get; set; }
        static int counter;
        static Product()
        {
            counter = 1000;
        }
        public Product()
        {
            ProductId = "P" + (++counter);
        }
        public Product(string productName, double price, int quantityAvailable, int categoryId) : this()
        {
            ProductName = productName;
            Price = price;
            QuantityAvailable = quantityAvailable;
            CategoryId = categoryId;
        }
    }
}

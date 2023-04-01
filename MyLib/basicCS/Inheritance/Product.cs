using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLib.basicCS.Inheritance
{
    public class Product
    {
        public string ProductId { get; set; }
        public string ProductName { get; set; }
        public byte CategoryId { get; set; }
        public double Price { get; set; }
        public int QuantityAvailable { get; set; }
        public Product(string productId, string productName, byte categoryId, double price, int quantityAvailable)
        {
            ProductId = productId;
            ProductName = productName;
            CategoryId = categoryId;
            Price = price;
            QuantityAvailable = quantityAvailable;
        }
    }

    public class Cart
    {
        //The class Cart HAS the Product as data type of the array which can store objects of Product class. This type of relationship between classes is called Aggregation or Has-A relationship.
        public Product[] CartProducts { get; set; }
        public Cart(Product[] products)
        {
            this.CartProducts = products;
        }
        public double[] FetchPriceList()
        {
            double[] priceList = null;
            if (this.CartProducts != null)
            {
                priceList = new double[CartProducts.Length];
                for (int i = 0; i < CartProducts.Length; i++)
                {
                    priceList[i] = CartProducts[i].Price;
                }
            }

            return priceList;
        }
    }

    public class Purchasev2
    {
        public double CalculateBillAmount(Cart cart)
        {
            double totalPrice = 0;
            double[] priceList = cart.FetchPriceList();
            if (priceList != null)
            {
                for (int i = 0; i < priceList.Length; i++)
                {
                    totalPrice += priceList[i];
                }
            }

            return totalPrice;
        }

    }


}

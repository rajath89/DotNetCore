using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLib.basicCS.Abstract
{
    public abstract class Seller
    {        
        public string SellerId { get; set; }
        public string SellerName { get; set; }
        public string[] SellerLocations { get; set; }

        public Seller(string sellerId, string sellerName, string[] sellerLocations)
        {
            SellerId = sellerId;
            SellerName = sellerName;
            SellerLocations = sellerLocations;
        }

             //Sign a contract to calculate the shipping charges among all the derived classes of Seller class
        public abstract double CalculateShippingCharges(string destination);
      
    }
}

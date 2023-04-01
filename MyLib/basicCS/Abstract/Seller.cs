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

        static int count;
        static Seller()
        {
            count = 1000;
        }
        Seller()
        {
            count++;
            SellerId = "S" + count;
        }

        public Seller(string sellerId, string sellerName, string[] sellerLocations)
        {
            SellerId = sellerId;
            SellerName = sellerName;
            SellerLocations = sellerLocations;
        }

        public Seller(string sellerName, string[] sellerLocations)
        {
           // SellerId = sellerId;
            SellerName = sellerName;
            SellerLocations = sellerLocations;
        }

        //Sign a contract to calculate the shipping charges among all the derived classes of Seller class
        public abstract double CalculateShippingCharges(string destination);

        public string GetSellerInformation()
        {
            string details = string.Empty;
            string locationDetails = string.Empty;
            details += string.Format("SellerId: {0}\nSellerName: {1}\n", this.SellerId, this.SellerName);
            foreach (string location in this.SellerLocations)
            {
                locationDetails += location + "\n";
            }
            details += string.Format("SellerLocations: \n{0}", locationDetails);
            return details;
        }

    }
}

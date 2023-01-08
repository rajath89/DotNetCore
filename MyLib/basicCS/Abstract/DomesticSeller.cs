using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLib.basicCS.Abstract
{
    public class DomesticSeller:Seller
    {
        public bool ExpressDelivery { get; set; }

        public DomesticSeller(string sellerId, string sellerName, 
                              string[] sellerLocations, bool expressDelivery)
                              : base(sellerId,sellerName,sellerLocations)
        {
            this.ExpressDelivery = expressDelivery;
        }

         //overidden method 
        public override double CalculateShippingCharges(string destination)
        {
            double shippingCharges = 0;
            if (SellerLocations.Contains(destination))
            {
                if (destination.Equals("New York") || destination.Equals("Chicago"))
                {
                    shippingCharges = 50;
                }
                else
                {
                    shippingCharges = 100;
                }
                if (ExpressDelivery)
                {
                    shippingCharges += 250;
                }
            }
            else
            {
                shippingCharges = 0;
            }
            return shippingCharges;
        }
       
    }
}

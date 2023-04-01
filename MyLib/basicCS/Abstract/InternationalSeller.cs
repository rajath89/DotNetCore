using MyLib.basicCS.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLib.basicCS.Abstract
{
    public class InternationalSeller:Seller, ITax
    {
        public double ExportCharge { get; set; }

        public InternationalSeller(string sellerId, string sellerName,
                                   string[] sellerLocations, double exportCharge) 
                                   : base(sellerId, sellerName, sellerLocations)
        {
            ExportCharge = exportCharge;
        }

        public InternationalSeller(string sellerName,
                                   string[] sellerLocations, double exportCharge)
                                   : base(sellerName, sellerLocations)
        {
            ExportCharge = exportCharge;
        }

        public override double CalculateShippingCharges(string destination)
        {
            double shippingCharges = 0;
            if (SellerLocations.Contains(destination))
            {
                shippingCharges = 1000;
                shippingCharges += ExportCharge;
            }
            else
            {
                shippingCharges = 0;
            } 
            return shippingCharges;
        }

        public double PayTax()
        {
            return 15;
        }



    }
}

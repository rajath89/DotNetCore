using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLib.basicCS.Interface
{
    public class Retailer : ITax, IStateTax
    {
        public string RetailerId { get; set; }
        public string RetailerName { get; set; }
        public string RetaileLocation { get; set; }
        public Retailer(string retailerId, string retailerName, string location)
        {
            RetailerId = retailerId;
            RetailerName = retailerName;
            RetaileLocation = location;
        }

        double ITax.PayTax()
        {
            return 25;
        }
        double IStateTax.PayTax()
        {
            return 0.45;
        }


    }
}

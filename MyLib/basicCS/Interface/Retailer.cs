using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLib.basicCS.Interface
{
    public class Retailer : ITax
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

        public double PayTax()
        {
            return 5;
        }

    }
}

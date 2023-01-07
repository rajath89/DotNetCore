using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLib.TypeCastExample
{
    public class RegularCustomer:Customer
    {
        public double DiscountPercentage { get; set; }

        public RegularCustomer(int custId, string custName, double discount) : base(custId, custName)
        {
            DiscountPercentage = discount;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLib.TypeCastExample
{
    public class EliteCustomer : Customer
    {
        public int CouponsOwned { get; set; }

        public EliteCustomer(int custId, string custName, int coupons) : base(custId, custName)
        {
            CouponsOwned = coupons;
        }
    }
}

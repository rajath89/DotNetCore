using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLib.TypeCastExample
{
    public class Customer
    {
        public int CustomerId { get; set; }
        public string CustormerName { get; set; }

        public Customer(int custId, string custName)
        {
            CustomerId = custId;
            CustormerName = custName;
        }

    }
}

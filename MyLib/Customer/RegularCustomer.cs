using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLib
{
    public class RegularCustomer: Customer
    {
        public double DiscountPercentage { get; set; }

        public RegularCustomer(string name, string contactNumber, string emailId, string address, double discountPercentage): base(name, contactNumber, emailId, address)
        {
            DiscountPercentage = discountPercentage;
        }
    }
}

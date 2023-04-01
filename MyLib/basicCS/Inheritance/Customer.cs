using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLib.basicCS.Inheritance
{
    public class Customer
    {
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string GetInfo()
        {
            return "QuickKart Customer";
        }

    }

    public class RegularCustomer : Customer //is-A or inheritance relationship
    {
        public double DiscountPercentage { get; set; }
        public double CalculateDiscount()
        {
            return DiscountPercentage / 100;
        }
    }

    public class EliteCustomer : Customer //is-A or inheritance relationship
    {
        public int CouponsOwned { get; set; }
        public double CalculateDiscount()
        {
            double discount = CouponsOwned * 0.01;
            this.CouponsOwned = 0;
            return discount;
        }
    }
}

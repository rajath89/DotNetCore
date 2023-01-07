using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLib
{
    public class Purchase
    {
        public double CalculateBillAmount(Customer customer, double billAmount)
        {
            double totalAmount = 0;
            if (customer is RegularCustomer)
            {
                RegularCustomer customerObj = customer as RegularCustomer;
                totalAmount = billAmount - (billAmount * customerObj.GetDiscount());
            }
            else if (customer is PrivilegedCustomer)
            {
                PrivilegedCustomer customerObj = customer as PrivilegedCustomer;
                totalAmount = billAmount - (billAmount * customerObj.GetDiscount());
            }
            else
                totalAmount = billAmount;
            return totalAmount;
        }
    }
}

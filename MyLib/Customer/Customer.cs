using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLib
{
    public class Customer
    {
        public string Name { get; set; }
        public string ContactNumber { get; set; }
        public string EMailId { get; set; }
        public string Address { get; set; }

        public Customer()
        {

        }

        public Customer(string name, string contactNumber, string emailId, string address)
        {
            Name = name;
            ContactNumber = contactNumber;
            EMailId = emailId;
            Address = address;
        }

        public string GetCustomerDetails()
        {
            return Name + " " + ContactNumber + " " + EMailId + " " + Address;
        }

        public double GetDiscount()
        {
            return 0.2;
        }
    }
}

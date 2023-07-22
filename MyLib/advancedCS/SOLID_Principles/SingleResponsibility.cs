using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLib.advancedCS.SOLID_Principles
{
    public class Customer
    {
        public string CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string ContactNumber { get; set; }
        public string EmailId { get; set; }
        public string Address { get; set; }

        public Customer(string customerId, string customerName, string contactNumber, string emailId, string address)
        {
            this.CustomerId = customerId;
            this.CustomerName = customerName;
            this.ContactNumber = contactNumber;
            this.EmailId = emailId;
            this.Address = address;
        }

        public string GetCustomerDetails()
        {
            string details = string.Format("{0, -15}: {1}\n{2, -15}: {3}\n{4, -15}: {5}\n" +
                 "{6, -15}: {7}\n{8, -15}: {9}",
                 "Customer Id", this.CustomerId, "Customer Name", this.CustomerName,
                 "ContactNumber", this.ContactNumber, "Email Id", this.EmailId,
                 "Address", this.Address);
            return details;
        }
        public string UpdateContactDetails(string contactNumber, string emailId, string address)
        {
            if (contactNumber != null)
            {
                this.ContactNumber = contactNumber;
            }
            if (emailId != null)
            {
                this.EmailId = emailId;
            }
            if (address != null)
            {
                this.Address = address;
            }
            return "\nContact Details UPDATED successfully!";
        }
    }

    public class PersistCustomerDetails
    {
        public Customer Customer { get; set; }
        public PersistCustomerDetails(Customer customer)
        {
            this.Customer = customer;
        }
        public string SaveCustomerDetails()
        {
            string path = @"D:\CustomerDetails.txt";
            FileStream fileStream = null;
            bool result = File.Exists(path);
            if (result)
                fileStream = new FileStream(path, FileMode.Open, FileAccess.Write);
            else
                fileStream = new FileStream(path, FileMode.CreateNew, FileAccess.Write);
            StreamWriter writer = new StreamWriter(fileStream);
            writer.WriteLine("{0}, {1}, {2}, {3}, {4}",
                Customer.CustomerId, Customer.CustomerName, Customer.ContactNumber,
                Customer.EmailId, Customer.Address);
            writer.Close();
            return "\nDetails SAVED successfully in a file!\n";
        }
    }

        internal class SingleResponsibility
        {
            public static void TestSingleResponsibility()
            {
                Customer customer = new Customer("C101", "Jenny", "9845054609", "jenny@gmail.com",
                    "Maple street, 5th cross road");
                Console.WriteLine("--------------------------------------");
                Console.WriteLine("           Customer Details           ");
                Console.WriteLine("--------------------------------------");
                string customerDetails = customer.GetCustomerDetails();
                Console.WriteLine(customerDetails);
                string updateStatus = customer.UpdateContactDetails("9995094609",
                        "jenny123@gmail.com", "Ivory Street, 10th Block");
                Console.WriteLine(updateStatus);
                Console.WriteLine("--------------------------------------");
                Console.WriteLine("       Updated Customer Details       ");
                Console.WriteLine("--------------------------------------");
                customerDetails = customer.GetCustomerDetails();
                Console.WriteLine(customerDetails);
                PersistCustomerDetails saveCustomerDetails = new PersistCustomerDetails(customer);
                string saveStatus = saveCustomerDetails.SaveCustomerDetails();
                Console.WriteLine(saveStatus);
        }
        }
}

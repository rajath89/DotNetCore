using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLib.advancedCS.Delegates
{
    public delegate string AlertDelegate(string customerName, string mediaType, int discount);
    delegate int NumberChanger(int n);
    public delegate int MyDelegate2(int num1, int num2);

    public class Example
    {
        // methods to be assigned and called by delegate
        public int Sum(int num1, int num2)
        {
            return num1 + num2;
        }

        public int Difference(int num1, int num2)
        {
            return num1 - num2;
        }

        public int Product(int num1, int num2)
        {
            return num1 * num2;
        }

        public int Modulo(int num1, int num2)
        {
            return num1 % num2;
        }

        public int Quotient(int num1, int num2)
        {
            return num1 / num2;
        }
    }

    class TestDelegate
    {
        static int num = 10;

        public static int AddNum(int p)
        {
            num += p;
            return num;
        }
        public static int MultNum(int q)
        {
            num *= q;
            return num;
        }
        public static int getNum()
        {
            return num;
        }

    }

    public static class Alerts
    {
        public static string SendSMS(string customerName, string phoneNumber, int discount)
        {
            string message = "SMS Sent to " + phoneNumber + "\nDear " + customerName +
                ", Avail " + discount +
                "% discount on all purchased items.\n";
            return message;
        }

        public static string SendEmail(string customerName, string emailId, int discount)
        {
            string message = "Email Sent to " + emailId + "\nDear " + customerName +
                ", Avail " + discount +
                "% discount on all purchased items.\n";
            return message;
        }

        public static string SendWhatsApp(string customerName, string phoneNumber, int discount)
        {
            string message = "WhatsApp message sent to " + phoneNumber + "\nDear " + customerName +
                ", Avail " + discount +
                "% discount on all purchased items.\n";
            return message;
        }
    }

    public class Customer
        {
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string Address { get; set; }
        public string EmailId { get; set; }
        public string PhoneNumber { get; set; }
        public AlertDelegate AlertPreferences { get; set; }

        static int counter;
        static Customer()
        {
            counter = 1000;
        }

        public Customer()
        {
            CustomerId = ++counter;
        }
        public Customer(string customerName, string address, string emailId,
            string phoneNumber, AlertDelegate alertPreferences) : base()
        {
            this.CustomerName = customerName;
            this.Address = address;
            this.EmailId = emailId;
            this.PhoneNumber = phoneNumber;
            this.AlertPreferences = alertPreferences;
        }
    }

    public class Sale
    {
        public Customer Customer { get; set; }
        public int Discount { get; set; }

        public Sale(Customer customer)
        {
            this.Customer = customer;
        }
        public string YearEndSale()
        {
            this.Discount = 15;
            string message = string.Empty;

            #region Multiple Alert Preferences

            foreach (AlertDelegate item in Customer.AlertPreferences.GetInvocationList())
            {
                if (item.Method.Name == "SendEmail")
                {
                    message += item(Customer.CustomerName, Customer.EmailId, Discount);
                }
                else
                {
                    message += item(Customer.CustomerName, Customer.PhoneNumber, Discount);
                }
            }

            #endregion

            return message;
        }

    }

    public class MultiCast
    {
        public static void TestMultiCastEx1()
        {
            AlertDelegate alert = Alerts.SendSMS;
            alert += Alerts.SendWhatsApp;
            alert += Alerts.SendEmail;

            //if customer decides does not want msg to be sent to whatsapp
            //alert -= Alerts.SendWhatsApp; 

            Customer customer = new Customer()
            {
                CustomerName = "Marcus",
                Address = "Santa Cruz",
                PhoneNumber = "9878677656",
                EmailId = "marcus01@gmail.com",
                AlertPreferences = alert
            };
            Sale sale = new Sale(customer);
            string yearEndSaleMessage = sale.YearEndSale();
            Console.WriteLine(yearEndSaleMessage);
        }

        public static void TestMultiCastEx2()
        {
            NumberChanger nc;
            NumberChanger nc1 = new NumberChanger(TestDelegate.AddNum);
            NumberChanger nc2 = new NumberChanger(TestDelegate.MultNum);

            nc = nc1;
            nc += nc2;

            //calling multicast
            nc(5);
            Console.WriteLine("Value of Num: {0}", TestDelegate.getNum());  //output : 75




            //ex3
            Example obj = new Example();
            // 3. More than one method can be invoked at once using multicast delegates
            Console.WriteLine("\n----- Multicast delegate operations -----");
            MyDelegate2 allOperations = obj.Sum;
            allOperations += obj.Difference;
            allOperations += obj.Product;
            allOperations += obj.Modulo;
            allOperations += obj.Quotient;
            foreach (MyDelegate2 delOperation in allOperations.GetInvocationList())
            {
                Console.WriteLine("Result: " + delOperation(20, 10));
            }
            /* GetInvocationList() has a list of all the methods to be executed using a delegate
             * This is useful when the methods return a value 
             * Every iteration in the loop executes a method and the returned result can be processed */


            // One should always be careful while implementing multicast delegates. 
            // If '=+' is accidently replaced with '=', it could break the chain
            // 4. Uncomment the below given code and execute the application
            //Console.WriteLine("\n----- Multicast delegate operations AGAIN -----");
            //MyDelegate allOperationsAgain = obj.Sum;
            //allOperationsAgain += obj.Difference;
            //allOperationsAgain += obj.Product;
            //allOperationsAgain += obj.Modulo;
            //allOperationsAgain = obj.Quotient;
            //foreach (MyDelegate delOperation in allOperationsAgain.GetInvocationList())
            //{
            //    Console.WriteLine("Result: " + delOperation(20, 10));
            //}
            /* Here the delegate is assigned with obj.Quotient method using a '='
             * and hence the previous list of assigned methods would be replaced only with one method */
        }

    }
}

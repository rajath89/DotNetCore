using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLib.advancedCS.Delegates
{
    public delegate string AlertDelegateSC(string customerName, string mediaType, int discount);
    delegate int NumberChangerSC(int n);
    public delegate int MyDelegate(int num1, int num2);

    public class SingleCast
    {
        private static string SendSMS(string customerName, string phoneNumber, int discount)
        {
            string message = "SMS Sent to " + phoneNumber + "\nDear " + customerName +
                ", Avail " + discount +
                "% discount on all purchased items.\n";
            return message;
        }

        private static string SendEmail(string customerName, string emailId, int discount)
        {
            string message = "Email Sent to " + emailId + "\nDear " + customerName +
                ", Avail " + discount +
                "% discount on all purchased items.\n";
            return message;
        }

        private static string SendWhatsApp(string customerName, string phoneNumber, int discount)
        {
            string message = "WhatsApp message sent to " + phoneNumber + "\nDear " + customerName +
                ", Avail " + discount +
                "% discount on all purchased items.\n";
            return message;
        }

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

        // methods to be assigned and called by delegate
        public static int Sum(int num1, int num2)
        {
            return num1 + num2;
        }

        public static int Difference(int num1, int num2)
        {
            return num1 - num2;
        }

        public static int Product(int num1, int num2)
        {
            return num1 * num2;
        }

        public static int Modulo(int num1, int num2)
        {
            return num1 % num2;
        }

        public static int Quotient(int num1, int num2)
        {
            return num1 / num2;
        }

        public static void TestSingleDelegateEx1()
        {
            AlertDelegateSC alert1 = new AlertDelegateSC(SingleCast.SendSMS);// OR AlertDelegate alert = SingleCast.SendSMS; 
            string message = alert1("Aurelius", "9807865432", 15);
            Console.WriteLine(message);

            AlertDelegateSC alert2 = new AlertDelegateSC(SingleCast.SendWhatsApp);// OR AlertDelegate alert = SingleCast.SendSMS; 
            string message2 = alert2("Aurelius", "9807865432", 15);
            Console.WriteLine(message2);

            AlertDelegateSC alert3 = new AlertDelegateSC(SingleCast.SendEmail);// OR AlertDelegate alert = SingleCast.SendSMS; 
            string message3 = alert3("Aurelius", "9807865432", 15);
            Console.WriteLine(message3);
        }

        public static void TestSingleDelegateEx2()
        {
            NumberChangerSC nc1 = new NumberChangerSC(AddNum);
            NumberChangerSC nc2 = new NumberChangerSC(MultNum);

            //calling the methods using the delegate objects
            nc1(25);
            Console.WriteLine("Value of Num: {0}", getNum());
            nc2(5);
            Console.WriteLine("Value of Num: {0}", getNum());
            Console.ReadKey();


            // Mydelegate
            /* 1. Instantiation: As a single cast delegate. 
             * Observe the two syntaxes for assigning a refernece of a 
             * method to the delegate reference variable */
            // Assigning the method using a constructor of the delegate
            MyDelegate sum = new MyDelegate(SingleCast.Sum);
            // Assigning the method without the constructor of the delegate
            MyDelegate diff = SingleCast.Difference;

            // 2. Invocation. Observe the two syntaxes to invoke a delegate
            // Using delegate object to invoke the method(s)
            Console.WriteLine("Sum of two integer is = " + sum(10, 20));
            // Using Invoke() to invoke the method(s)
            Console.WriteLine("Difference of two integer is = " + diff.Invoke(20, 10));
        }
    }
}

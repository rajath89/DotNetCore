namespace MyLib;
public class Customer
{
        public string customerName;
        public string customerAddress;
        public string customerContact;       
        public void MyProfile()
        {
            Console.WriteLine("Print Customer Details");            
        }

        public void Add(double x, int y)
        {
            Console.WriteLine("Sum of double and int " + (x + y));
        }

        // Third Add method
        public void Add(int x, double y)
        {
            Console.WriteLine("Sum of int and double " + (x + y));
        }
}

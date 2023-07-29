using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLib.advancedCS.Delegates
{
    delegate void NumberChangerAM(double n);
    public delegate double BirthdayDelegate(double amount);
    public delegate float SimpleInterestDelegate(float principle, float rate, float time);
    public delegate int GetProductsDelegate(int categoryId);

    public class Category
    {
        private static int Count = 1;
        public Category()
        {
            CategoryId = Count;
            Count++;
        }

        public int CategoryId { get; set; }

        public string CategoryName { get; set; }
    }

    public class Product
    {
        private static int Count = 1000;
        public Product()
        {
            ProductId = Count;
            Count++;
        }

        public Category Category { get; set; }

        public string ProductName { get; set; }

        public double Price { get; set; }

        public int ProductId { get; set; }

        public int QuantityAvailable { get; set; }
    }

    public class DelegatesEnhancement
    {
        static double num;

        private static void AddNum(double p)
        {
            num += p;
            Console.WriteLine("Named Method: {0}", num);
        }
        private static void MultNum(double q)
        {
            num *= q;
            Console.WriteLine("Named Method: {0}", num);
        }

        private static bool IsUpperCase(string str)
        {
            return str.Equals(str.ToUpper());
        }

        public static void AnonymousMethod()
        {
            BirthdayDelegate discountDel = delegate (double amount)
            {
                double discountAmount = amount * 0.2;
                return discountAmount;
            };
            double discountCustomerOne = discountDel(2500);
            Console.WriteLine("Amount after applying 20% discount = " + discountCustomerOne);
            double discountCustomerTwo = discountDel(5600);
            Console.WriteLine("Amount after applying 20% discount = " + discountCustomerTwo);
            double discountCustomerThree = discountDel(4000);
            Console.WriteLine("Amount after applying 20% discount = " + discountCustomerThree);



            //ex2

            //*Single cast delegate anonymous method*
            NumberChangerAM nc1 = delegate (double n)
            {
                num = Math.Ceiling(n);
                Console.WriteLine("Ceil value of {0} is : {1}", n, num);
            };
            nc1.Invoke(10.56);

            //calling the delegate using the anonymous method 
            nc1(10);

            //instantiating the delegate using the named methods 
            nc1 = new NumberChangerAM(DelegatesEnhancement.AddNum);

            //calling the delegate using the named methods 
            nc1(5);

            //instantiating the delegate using another named methods 
            nc1 = new NumberChangerAM(DelegatesEnhancement.MultNum);

            //calling the delegate using the named methods 
            nc1(2);




            //*Multicast delegate with anonymous methods */
            Console.WriteLine("\n----- Multicast delegate with anonymous methods -----");
            NumberChangerAM nc = delegate (double n)
            {
                num = Math.Ceiling(n);
                Console.WriteLine("Ceil value of {0} is : {1}", n, num);
            };
            nc += delegate (double n)
            {
                num = Math.Floor(n);
                Console.WriteLine("Floor value of {0} is : {1}", n, num);
            };
            nc += delegate (double n)
            {
                num = Math.Sqrt(n);
                Console.WriteLine("Square root of {0} is : {1}", n, num);
            };
            nc.Invoke(10.56);

        }

        public static void LambdaExpression()
        {
            //ex1
            BirthdayDelegate discountDel = x => x * 0.2;

            var del = discountDel(30);


            //ex2
            float principle = 15000.00f;
            float time = 1.5f;
            float rate = 7.8f;

            //An anonymous method implementation for calculating Simple interest: 
            //Method 1
            SimpleInterestDelegate simpleDel = delegate (float p, float r, float t) {
                float simpleInterest = p + (1 + r * t);
                return simpleInterest;
            };

            Console.WriteLine("Simple Interest using anonymous method: " + simpleDel(principle, rate, time));


            //However, this could also be easily done using lambda expression. Comment the Method1
            SimpleInterestDelegate simpleLambda = (p, r, t) => p + (1 + r * t); 
            Console.WriteLine("Simple Interest using anonymous method: " + simpleLambda(principle, rate, time));



            //ex3
            int[] source = new[] { 13, 28, 4, 16, 11, 27, 9, 42, 24, 8 };

            foreach (int i in source.Where(
                x =>
                {
                    if ((x / 4) <= 3)
                        return true;
                    else if ((x / 4) >= 7)
                        return true;
                    return false;
                }))
                Console.WriteLine(i);
            /*
              ans:
                13   
                28   
                4   
                11  
                9   
                42   
                8
             */


            //ex4
            // Test data: Creating categories and products
            Category category1 = new Category { CategoryName = "Sports" };
            Category category2 = new Category { CategoryName = "Electronics" };

            Product product1 = new Product { Category = category1, ProductName = "Tennis Racket", Price = 1099.99, QuantityAvailable = 50 };
            Product product2 = new Product { Category = category1, ProductName = "Tennis Ball", Price = 300.00, QuantityAvailable = 100 };
            Product product3 = new Product { Category = category2, ProductName = "Laptop", Price = 800.00, QuantityAvailable = 25 };

            // GetProductsDelegate using Lambda Expression
            GetProductsDelegate getProductsDelegate = (categoryId) =>
            {
                int totalProducts = 0;
                // Count the number of products with the given categoryId
                if (product1.Category.CategoryId == categoryId)
                    totalProducts += product1.QuantityAvailable;

                if (product2.Category.CategoryId == categoryId)
                    totalProducts += product2.QuantityAvailable;

                if (product3.Category.CategoryId == categoryId)
                    totalProducts += product3.QuantityAvailable;

                return totalProducts;
            };

            // Test the GetProductsDelegate
            int categoryId1 = 1; // CategoryId of Sports category
            int categoryId2 = 2; // CategoryId of Electronics category

            int totalProductsInCategory1 = getProductsDelegate(categoryId1);
            int totalProductsInCategory2 = getProductsDelegate(categoryId2);

            Console.WriteLine($"Total products in Sports category: {totalProductsInCategory1}");
            Console.WriteLine($"Total products in Electronics category: {totalProductsInCategory2}");

        }

        public static void BuiltInDelegates()
        {
            #region Func delegate

            //--example1--
            Func<double, double> discountDel = x => x * 0.2;

            double discountCustomerOne = discountDel(2500);
            Console.WriteLine("Amount after applying 20% discount = " + discountCustomerOne);
            double discountCustomerTwo = discountDel(5600);
            Console.WriteLine("Amount after applying 20% discount = " + discountCustomerTwo);
            double discountCustomerThree = discountDel(4000);
            Console.WriteLine("Amount after applying 20% discount = " + discountCustomerThree);

            Func<Product, bool> checkPrice = p => p.Price > 0;
            Console.WriteLine();

            Product product = new Product();
            product.ProductName = "Tennis Racket";
            product.Price = 1500;
            product.QuantityAvailable = 15;
            bool result = checkPrice(product);
            Console.WriteLine("Result = " + result);

            //--example2--
            Func<int, int, int> findSum = (a, b) => a + b;
            Console.WriteLine("Sum ->" + findSum(1, 2));

            #endregion


            #region Action Delegate

            //--example1--
            Action<Product, int> checkQuantity = (x, y) =>
            {
                if (x.QuantityAvailable > y)
                {
                    Console.WriteLine("Sufficient Quantity!");
                }
                else
                {
                    Console.WriteLine("Insufficient Quantity!!");
                }
            };

            checkQuantity(product, 5);

            //--example2--
            Action<int> findFactorial = (n) => {
                int res = 1;
                for (int i = 1; i <= n; i++)
                {
                    res = res * i;
                }
                Console.WriteLine("Factorial of {0}: {1}", n, res);
            };

            findFactorial(5);


            //--example3--
            Action action = () => { 
                Console.WriteLine("Action can also accept 0 paramaters and not return any value. They can be used to print results or store methods which matches its signature and doesn't return anything");  
            };

            action();

            #endregion


            #region Predicate delegate

            //--example 1
            Predicate<Product> checkPricePred = x => x.Price > 0;

            //Product product = new Product("Tennis Racket", 1500, 15, 1);
            bool resultPred = checkPricePred(product);
            Console.WriteLine("Result = " + resultPred);

            //--example 2--
            Predicate<int> checkPalindrome = (n) => {
                int result = 0;
                var temp = n;
                while (temp != 0)
                {
                    var remainder = temp % 10;
                    result = result * 10 + remainder;
                    temp = temp / 10;
                }
                if (result == n)
                {
                    return true;
                }
                return false;
            };

            Console.WriteLine("Palindrome " + checkPalindrome(121));

            //--example 3--
            Predicate<string> isUpper = s => s.Equals(s.ToUpper());
            result = isUpper("hello world!!");
            Console.WriteLine(result);


            //--example 4 (Predicate delegate)--
            Predicate<string> isUpperPred = IsUpperCase;
            bool result2 = isUpper("hello world!!");
            Console.WriteLine(result);

            //--example 5 (Predicate delegate with anonymous method)
            Predicate<string> isUpperAM = IsUpperCase;
            isUpperAM = delegate (string s) { return s.Equals(s.ToUpper()); };
            bool result3 = isUpperAM("hello world!!");
            Console.WriteLine(result3);

            #endregion

        }
    }
}

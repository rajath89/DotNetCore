using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLib.advancedCS.LINQ
{
    public class QuerySyntax
    {
        public List<Category> CategoryList { get; set; }

        public List<Product> ProductList { get; set; }

        public QuerySyntax()
        {
            this.CreateCategoryAndProduct();
        }
        private void CreateCategoryAndProduct()
        {
            CategoryList = new List<Category>()
            {
                new Category { CategoryName = "Sports" },
                new Category { CategoryName = "Furniture" },
                new Category { CategoryName = "Apparels" }
            };

            ProductList = new List<Product>()
            {
                 new Product { ProductName="Tennis Racket", Price=1099.99, QuantityAvailable=50, CategoryId=1 },
                 new Product { ProductName="Tennis Ball", Price=300.00, QuantityAvailable=100, CategoryId=1 },
                 new Product { ProductName="Dining Table", Price=15000, QuantityAvailable=10, CategoryId=2 },
                 new Product { ProductName="Laptop Table", Price=7000.00, QuantityAvailable=15, CategoryId=2 },
                 new Product { ProductName="Corduroy Shirt", Price=2000, QuantityAvailable=100, CategoryId=3 },
                 new Product { ProductName="Tweed Shirt", Price=2500, QuantityAvailable=100, CategoryId=3 }
            };
        }

        public void TestLINQ()
        {
            

            var productList = ProductList;
            var categoryList = CategoryList;


            #region Query 1Display the product names of all the available products in QuickKart

            // i.Deffered Execution
            var allProductNames = from product in productList
                                  select product.ProductName;
            Console.WriteLine("-----------------------------------");
            Console.WriteLine("Product Names (Deferred Execution)");
            Console.WriteLine("-----------------------------------");
            foreach (var item in allProductNames)
            {
                Console.WriteLine(item);
            }

            // ii. Immediate execution
            List<string> allProductNamesTwo = (from product in productList
                                               select product.ProductName).ToList();
            Console.WriteLine("-----------------------------------");
            Console.WriteLine("Product Names (Immediate Execution)");
            Console.WriteLine("-----------------------------------");
            foreach (var item in allProductNamesTwo)
            {
                Console.WriteLine(item);
            } 
            #endregion

            #region Difference between deferred and immediate execution
            productList.Add(new Product
            {
                ProductName = "Soccer Ball",
                Price = 500.00,
                QuantityAvailable = 100,
                CategoryId = 1
            });
            Console.WriteLine("-----------------------------------");
            Console.WriteLine("Product Names (Deferred Execution)");
            Console.WriteLine("-----------------------------------");
            foreach (var item in allProductNames)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("-----------------------------------");
            Console.WriteLine("Product Names (Immediate Execution)");
            Console.WriteLine("-----------------------------------");
            foreach (var item in allProductNamesTwo)
            {
                Console.WriteLine(item);
            }
            int noOfProducts = (from product in productList
                                select product.ProductName).Count();
            Console.WriteLine("-----------------------------------");
            Console.WriteLine("Number of products available = " + noOfProducts);
            Console.WriteLine("-----------------------------------");
            #endregion

            #region Query 2. Display the product names as well as price of all the available products in QuickKart

            var productPriceList = (from product in productList
                                    select new { product.ProductName, product.Price })
                                   .ToList();
            Console.WriteLine("-----------------------------------");
            Console.WriteLine("{0, -20}{1}", "ProductName", "Price");
            Console.WriteLine("-----------------------------------");
            foreach (var item in productPriceList)
            {
                Console.WriteLine("{0, -20}{1}", item.ProductName, item.Price);
            }
            #endregion

            #region Query 3.Display the product names as well as price of all those products which are priced above Rs.1000

            var productPriceFilter = (from product in productList
                                      where product.Price > 1000
                                      select new { product.ProductName, product.Price })
                                     .ToList();

            Console.WriteLine("\n-----------------------------------");
            Console.WriteLine("Product details greater than 1000");
            Console.WriteLine("-----------------------------------");
            Console.WriteLine("{0, -20}{1}", "ProductName", "Price");
            Console.WriteLine("-----------------------------------");
            foreach (var item in productPriceFilter)
            {
                Console.WriteLine("{0, -20}{1}", item.ProductName, item.Price);
            }
            #endregion

            #region Query 4.Display the product names as well as price of all those products which are priced above Rs.1000 and in the decreasing order of price
            var productPriceSort = (from product in productList
                                    where product.Price > 1000
                                    orderby product.Price descending
                                    select new { product.ProductName, product.Price })
                                       .ToList();

            Console.WriteLine("\n------------------------------------------------------------");
            Console.WriteLine("Product details greater than 1000 sorted in descending order");
            Console.WriteLine("------------------------------------------------------------");
            Console.WriteLine("{0, -20}{1}", "ProductId", "ProductName");
            Console.WriteLine("-----------------------------------");
            foreach (var item in productPriceSort)
            {
                Console.WriteLine("{0, -20}{1}", item.ProductName, item.Price);
            }
            #endregion

            #region Query 5.Display the category id and number of products available in each category.Group the data with Category Id.
            var productGroup = from product in productList
                               group product by product.CategoryId
                                            into g
                               select new { g.Key, NumberOfProducts = g.Count() };
            Console.WriteLine("\n--------------------------------------");
            Console.WriteLine("Number of Products under each category");
            Console.WriteLine("--------------------------------------");
            Console.WriteLine("{0, -20}{1}", "CategoryId", "Number of Products");
            Console.WriteLine("--------------------------------------");
            foreach (var item in productGroup)
            {
                Console.WriteLine("{0, -20}{1}", item.Key, item.NumberOfProducts);
            }
            #endregion

            #region Query 6.Display the product name, category name and price of all the products.
            var productCategoryList = from product in productList
                                      join
                                      category in categoryList
                                      on product.CategoryId equals category.CategoryId
                                      select new
                                      {
                                          category.CategoryName,
                                          product.ProductName,
                                          product.Price
                                      };
            Console.WriteLine("\n--------------------------------------------");
            Console.WriteLine("Product and category details with the price");
            Console.WriteLine("--------------------------------------------");
            Console.WriteLine("{0, -18}{1, -18}{2}", "CategoryName", "ProductName", "Price");
            Console.WriteLine("--------------------------------------------");
            foreach (var item in productCategoryList)
            {
                Console.WriteLine("{0, -18}{1, -18}{2}", item.CategoryName, item.ProductName, item.Price);
            }
            #endregion

            #region Query 7.Display the category Id and the total quantity of products available in each category in the ascending order of total quantity available
            var productTotalQuantity = from product in productList
                                       join category in categoryList
                                       on product.CategoryId equals category.CategoryId
                                       group product by product.CategoryId
                                       into g
                                       orderby g.Sum(p => p.QuantityAvailable) ascending
                                       select new { g.Key, Total = g.Sum(p => p.QuantityAvailable) };
            Console.WriteLine("\n---------------------------------------------------");
            Console.WriteLine("Total number of products available in each category");
            Console.WriteLine("---------------------------------------------------");
            Console.WriteLine("{0, -15}{1, -15}", "CategoryID", "Total Products");
            Console.WriteLine("-----------------------------");
            foreach (var item in productTotalQuantity)
            {
                Console.WriteLine("{0, -15}{1, -15}", item.Key, item.Total);
            }
            Console.WriteLine();
            #endregion

        }

    }
}

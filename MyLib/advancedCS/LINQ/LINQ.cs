using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLib.advancedCS.LINQ
{
    public class LINQ
    {
        public List<Category> CategoryList { get; set; }

        public List<Product> ProductList { get; set; }

        public List<Unit> UnitList { get; set; }

        public List<Employee> EmployeeList { get; set; }

        public List<Accounts> AccountsList { get; set; }

        //public LINQ()
        //{
        //    this.CreateCategoryAndProduct();
        //    this.CreateUnitAndEmployee();
        //}
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

        private void CreateUnitAndEmployee()
        {
            UnitList = new List<Unit>()
            {
             new Unit{ UnitId = 10, UnitName = "ETA"},
             new Unit{ UnitId = 20, UnitName = "FSI"},
             new Unit{ UnitId = 30, UnitName = "ECS"}
            };
        
            EmployeeList = new List<Employee>()
            {
                 new Employee {EmployeeName = "John",UnitId=10,ProjectCode="ETAMYS",Salary=30000,JobLevel=3,JoiningDate=new DateTime(2014,3,5)},
                 new Employee {EmployeeName = "Jack",UnitId=10,ProjectCode="ETACHN",Salary=35000,JobLevel=3,JoiningDate=new DateTime(2011,3,5)},
                 new Employee {EmployeeName = "Albus",UnitId=10,ProjectCode="ETACHN",Salary=15000,JobLevel=4,JoiningDate=new DateTime(2011,3,5)},
                 new Employee {EmployeeName = "Ron",UnitId=20,ProjectCode="FSIAUS",Salary=10000,JobLevel=4,JoiningDate=new DateTime(2007,2,5)},
                 new Employee {EmployeeName = "Iwa",UnitId=20,ProjectCode="FSIAUS",Salary=15000,JobLevel=4,JoiningDate=new DateTime(2007,2,5)},
                 new Employee {EmployeeName = "Albert",UnitId=30,ProjectCode=null,Salary=20000,JobLevel=3,JoiningDate=new DateTime(2005,1,5)}
            };
        }


        private void CreateAccounts()
        {
            AccountsList = new List<Accounts>
            {
            new Accounts { AccountNumber = "A001", AccountType = "Savings", BankId = "B001", CustomerName = "John", Balance = 1200, RewardPoints = 50 },
            new Accounts { AccountNumber = "A002", AccountType = "Salary", BankId = "B002", CustomerName = "Vivekananda", Balance = 500, RewardPoints = 75 },
            new Accounts { AccountNumber = "A003", AccountType = "Savings", BankId = "B003", CustomerName = "Mary", Balance = 3000, RewardPoints = 100 },
            new Accounts { AccountNumber = "A004", AccountType = "Salary", BankId = "B004", CustomerName = "Vivekananda", Balance = 2000, RewardPoints = 90 }
        };
        }

        public void TestLINQQuerySyntax()
        {
            if (ProductList == null && CategoryList == null)
                this.CreateCategoryAndProduct();

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

        public void LINQExercise1(bool isQuerySyntax)
        {
            #region Problem Statements:
            /*

                Display the EmployeeName, UnitId and ProjectCode of those Employees, whose Salary is between 15000 and 20000.
                Display the EmployeeName, TotalExperience in years of those employees, who have more than three years of experience.
                Display the EmployeeName of those employees, who are not assigned to any project.
                Display the total amount of Salary drawn by all the employees.
                Display the total amount of salaries drawn by all those employees, who are in JobLevel 3.
                 Display the EmployeeName and UnitName of all the employees in the ascending order of employee names.
                Display the EmployeeName and Salary of employee(s), who are drawing minimum salary.
                Display the EmployeeName and JoiningDate of employee(s), who are the most experienced.
                Display the UnitId and number of employees in each unit.
                Display the UnitId and Number of employees in each unit, whose Salary is greater than 10000.
                Display the UnitId and total amount of salaries drawn by employees in each unit.
                Display the UnitId and total salary drawn by employees for all those units where the unit's total salary is greater than 20000.
                Display the UnitId and total salary drawn by employees of job level 3 in each unit for all those units where total salary of all JobLevel 3 employees is greater than 20000.
                Display the UnitName and maximum salary drawn by employees in each unit in the descending order of maximum salary.
                Display the EmployeeName, UnitId, Salary and ProjectCode of those employees, who draw minimum salary in each unit.
                Display the EmployeeName, UnitName, Salary and ProjectCode of those employees, whose Salary is greater than the average salary in their unit.
                Display the UnitId, JobLevel and number of employees in that unit and job level. (Hint: Group by unit id and job level)
                */
            #endregion

            if (EmployeeList == null && UnitList == null)
                this.CreateUnitAndEmployee();

            bool IsQuerySyntax = isQuerySyntax;

            var employeeList = EmployeeList;
            var unitList = UnitList;

            if(!IsQuerySyntax)
            {
                // 1. Display the EmployeeName, UnitId, and ProjectCode of those Employees whose Salary is between 15000 and 20000.
                var query1 = employeeList.Where(emp => emp.Salary >= 15000 && emp.Salary <= 20000);
                foreach (var emp in query1)
                {
                    Console.WriteLine($"EmployeeName: {emp.EmployeeName}, UnitId: {emp.UnitId}, ProjectCode: {emp.ProjectCode}");
                }

                // 2. Display the EmployeeName and TotalExperience in years of those employees who have more than three years of experience.
                var query2 = employeeList.Where(emp => (DateTime.Now - emp.JoiningDate).TotalDays > 1095);
                foreach (var emp in query2)
                {
                    int totalExperience = (int)(DateTime.Now - emp.JoiningDate).TotalDays / 365;
                    Console.WriteLine($"EmployeeName: {emp.EmployeeName}, TotalExperience: {totalExperience} years");
                }

                // 3. Display the EmployeeName of those employees who are not assigned to any project.
                var query3 = employeeList.Where(emp => string.IsNullOrEmpty(emp.ProjectCode));
                foreach (var emp in query3)
                {
                    Console.WriteLine($"EmployeeName: {emp.EmployeeName}");
                }

                // 4. Display the total amount of Salary drawn by all the employees.
                double totalSalary = employeeList.Sum(emp => emp.Salary);
                Console.WriteLine($"Total Salary: {totalSalary}");

                // 5. Display the total amount of salaries drawn by all those employees who are in JobLevel 3.
                double totalSalaryJobLevel3 = employeeList.Where(emp => emp.JobLevel == 3).Sum(emp => emp.Salary);
                Console.WriteLine($"Total Salary of JobLevel 3 employees: {totalSalaryJobLevel3}");

                // 6. Display the EmployeeName and UnitName of all the employees in ascending order of employee names.
                var query6 = employeeList.OrderBy(emp => emp.EmployeeName)
                                          .Join(unitList, emp => emp.UnitId, unit => unit.UnitId, (emp, unit) => new { emp, unit });
                foreach (var item in query6)
                {
                    Console.WriteLine($"EmployeeName: {item.emp.EmployeeName}, UnitName: {item.unit.UnitName}");
                }

                // 7. Display the EmployeeName and Salary of employee(s) who are drawing the minimum salary.
                var minSalary = employeeList.Min(emp => emp.Salary);
                var query7 = employeeList.Where(emp => emp.Salary == minSalary);
                foreach (var emp in query7)
                {
                    Console.WriteLine($"EmployeeName: {emp.EmployeeName}, Salary: {emp.Salary}");
                }

                // 8. Display the EmployeeName and JoiningDate of employee(s) who are the most experienced.
                var mostExperiencedDate = employeeList.Min(emp => emp.JoiningDate);
                var query8 = employeeList.Where(emp => emp.JoiningDate == mostExperiencedDate);
                foreach (var emp in query8)
                {
                    Console.WriteLine($"EmployeeName: {emp.EmployeeName}, JoiningDate: {emp.JoiningDate}");
                }

                // 9. Display the UnitId and number of employees in each unit.
                var query9 = employeeList.GroupBy(emp => emp.UnitId)
                                         .Select(g => new { UnitId = g.Key, Count = g.Count() });
                foreach (var item in query9)
                {
                    Console.WriteLine($"UnitId: {item.UnitId}, Number of employees: {item.Count}");
                }

                // 10. Display the UnitId and Number of employees in each unit, whose Salary is greater than 10000.
                var query10 = employeeList.Where(emp => emp.Salary > 10000)
                                          .GroupBy(emp => emp.UnitId)
                                          .Select(g => new { UnitId = g.Key, Count = g.Count() });
                foreach (var item in query10)
                {
                    Console.WriteLine($"UnitId: {item.UnitId}, Number of employees with Salary > 10000: {item.Count}");
                }

                // 11. Display the UnitId and total amount of salaries drawn by employees in each unit.
                var query11 = employeeList.GroupBy(emp => emp.UnitId)
                                          .Select(g => new { UnitId = g.Key, TotalSalary = g.Sum(emp => emp.Salary) });
                foreach (var item in query11)
                {
                    Console.WriteLine($"UnitId: {item.UnitId}, Total Salary: {item.TotalSalary}");
                }

                // 12. Display the UnitId and total salary drawn by employees for all those units where the unit's total salary is greater than 20000.
                var query12 = employeeList.GroupBy(emp => emp.UnitId)
                                          .Where(g => g.Sum(emp => emp.Salary) > 20000)
                                          .Select(g => new { UnitId = g.Key, TotalSalary = g.Sum(emp => emp.Salary) });
                foreach (var item in query12)
                {
                    Console.WriteLine($"UnitId: {item.UnitId}, Total Salary: {item.TotalSalary}");
                }

                // 13. Display the UnitId and total salary drawn by employees of job level 3 in each unit for all those units where the total salary of all JobLevel 3 employees is greater than 20000.
                var query13 = employeeList.Where(emp => emp.JobLevel == 3)
                                          .GroupBy(emp => emp.UnitId)
                                          .Where(g => g.Sum(emp => emp.Salary) > 20000)
                                          .Select(g => new { UnitId = g.Key, TotalSalary = g.Sum(emp => emp.Salary) });
                foreach (var item in query13)
                {
                    Console.WriteLine($"UnitId: {item.UnitId}, Total Salary of JobLevel 3 employees: {item.TotalSalary}");
                }

                // 14. Display the UnitName and maximum salary drawn by employees in each unit in descending order of maximum salary.
                var query14 = employeeList.GroupBy(emp => emp.UnitId)
                                          .Select(g => new { UnitId = g.Key, MaxSalary = g.Max(emp => emp.Salary) })
                                          .Join(unitList, emp => emp.UnitId, unit => unit.UnitId, (emp, unit) => new { UnitName = unit.UnitName, MaxSalary = emp.MaxSalary })
                                          .OrderByDescending(emp => emp.MaxSalary);
                foreach (var item in query14)
                {
                    Console.WriteLine($"UnitName: {item.UnitName}, Maximum Salary: {item.MaxSalary}");
                }

                // 15. Display the EmployeeName, UnitId, Salary, and ProjectCode of those employees who draw the minimum salary in each unit.
                var query15 = employeeList.GroupBy(emp => emp.UnitId)
                                          .Select(g => new { UnitId = g.Key, MinSalary = g.Min(emp => emp.Salary) })
                                          .Join(employeeList, emp => new { emp.UnitId, emp.MinSalary }, emp2 => new { emp2.UnitId, MinSalary = emp2.Salary }, (emp, emp2) => emp2);
                foreach (var emp in query15)
                {
                    Console.WriteLine($"EmployeeName: {emp.EmployeeName}, UnitId: {emp.UnitId}, Salary: {emp.Salary}, ProjectCode: {emp.ProjectCode}");
                }

                // 16. Display the EmployeeName, UnitName, Salary, and ProjectCode of those employees whose Salary is greater than the average salary in their unit.
                var query16 = employeeList.GroupBy(emp => emp.UnitId)
                                          .Select(g => new { UnitId = g.Key, AvgSalary = g.Average(emp => emp.Salary) })
                                          .Join(employeeList, emp => emp.UnitId, emp2 => emp2.UnitId, (emp, emp2) => new { emp2.EmployeeName, emp2.UnitId, emp2.Salary, emp2.ProjectCode, emp.AvgSalary })
                                          .Where(emp => emp.Salary > emp.AvgSalary);
                foreach (var emp in query16)
                {
                    Console.WriteLine($"EmployeeName: {emp.EmployeeName}, UnitId: {emp.UnitId}, Salary: {emp.Salary}, ProjectCode: {emp.ProjectCode}");
                }

                // 17. Display the UnitId, JobLevel, and the number of employees in that unit and job level. (Hint: Group by unit id and job level)
                var query17 = employeeList.GroupBy(emp => new { emp.UnitId, emp.JobLevel })
                                          .Select(g => new { UnitId = g.Key.UnitId, JobLevel = g.Key.JobLevel, Count = g.Count() });
                foreach (var emp in query17)
                {
                    Console.WriteLine($"UnitId: {emp.UnitId}, JobLevel: {emp.JobLevel}, Number of employees: {emp.Count}");
                }
            }
            else
            {
                // Problem Statement 1: Display the EmployeeName, UnitId, and ProjectCode of those Employees whose Salary is between 15000 and 20000.
                var query1 = from emp in employeeList
                             where emp.Salary >= 15000 && emp.Salary <= 20000
                             select new { emp.EmployeeName, emp.UnitId, emp.ProjectCode };

                foreach (var emp in query1)
                {
                    Console.WriteLine($"EmployeeName: {emp.EmployeeName}, UnitId: {emp.UnitId}, ProjectCode: {emp.ProjectCode}");
                }

                // Problem Statement 2: Display the EmployeeName and TotalExperience in years of those employees who have more than three years of experience.
                var query2 = from emp in employeeList
                             where (DateTime.Now - emp.JoiningDate).TotalDays > 1095
                             select new { emp.EmployeeName, TotalExperience = (int)(DateTime.Now - emp.JoiningDate).TotalDays / 365 };

                foreach (var emp in query2)
                {
                    Console.WriteLine($"EmployeeName: {emp.EmployeeName}, TotalExperience: {emp.TotalExperience} years");
                }

                // Problem Statement 3: Display the EmployeeName of those employees who are not assigned to any project.
                var query3 = from emp in employeeList
                             where string.IsNullOrEmpty(emp.ProjectCode)
                             select emp.EmployeeName;

                foreach (var empName in query3)
                {
                    Console.WriteLine($"EmployeeName: {empName}");
                }

                // Problem Statement 4: Display the total amount of Salary drawn by all the employees.
                var query4 = employeeList.Sum(emp => emp.Salary);
                Console.WriteLine($"Total Salary: {query4}");

                // Problem Statement 5: Display the total amount of salaries drawn by all those employees who are in JobLevel 3.
                var query5 = employeeList.Where(emp => emp.JobLevel == 3).Sum(emp => emp.Salary);
                Console.WriteLine($"Total Salary of JobLevel 3 employees: {query5}");

                // Problem Statement 6: Display the EmployeeName and UnitName of all the employees in ascending order of employee names.
                var query6 = from emp in employeeList
                             join unit in unitList on emp.UnitId equals unit.UnitId
                             orderby emp.EmployeeName
                             select new { emp.EmployeeName, unit.UnitName };

                foreach (var emp in query6)
                {
                    Console.WriteLine($"EmployeeName: {emp.EmployeeName}, UnitName: {emp.UnitName}");
                }

                // Problem Statement 7: Display the EmployeeName and Salary of employee(s) who are drawing the minimum salary.
                var minSalary = employeeList.Min(emp => emp.Salary);
                var query7 = from emp in employeeList
                             where emp.Salary == minSalary
                             select new { emp.EmployeeName, emp.Salary };

                foreach (var emp in query7)
                {
                    Console.WriteLine($"EmployeeName: {emp.EmployeeName}, Salary: {emp.Salary}");
                }

                // Problem Statement 8: Display the EmployeeName and JoiningDate of employee(s) who are the most experienced.
                var mostExperiencedDate = employeeList.Min(emp => emp.JoiningDate);
                var query8 = from emp in employeeList
                             where emp.JoiningDate == mostExperiencedDate
                             select new { emp.EmployeeName, emp.JoiningDate };

                foreach (var emp in query8)
                {
                    Console.WriteLine($"EmployeeName: {emp.EmployeeName}, JoiningDate: {emp.JoiningDate}");
                }

                // Problem Statement 9: Display the UnitId and number of employees in each unit.
                var query9 = from emp in employeeList
                             group emp by emp.UnitId into g
                             select new { UnitId = g.Key, Count = g.Count() };

                foreach (var item in query9)
                {
                    Console.WriteLine($"UnitId: {item.UnitId}, Number of employees: {item.Count}");
                }

                // Problem Statement 10: Display the UnitId and Number of employees in each unit, whose Salary is greater than 10000.
                var query10 = from emp in employeeList
                              where emp.Salary > 10000
                              group emp by emp.UnitId into g
                              select new { UnitId = g.Key, Count = g.Count() };

                foreach (var item in query10)
                {
                    Console.WriteLine($"UnitId: {item.UnitId}, Number of employees with Salary > 10000: {item.Count}");
                }

                // Problem Statement 11: Display the UnitId and total amount of salaries drawn by employees in each unit.
                var query11 = from emp in employeeList
                              group emp by emp.UnitId into g
                              select new { UnitId = g.Key, TotalSalary = g.Sum(emp => emp.Salary) };

                foreach (var item in query11)
                {
                    Console.WriteLine($"UnitId: {item.UnitId}, Total Salary: {item.TotalSalary}");
                }

                // Problem Statement 12: Display the UnitId and total salary drawn by employees for all those units where the unit's total salary is greater than 20000.
                var query12 = from emp in employeeList
                              group emp by emp.UnitId into g
                              where g.Sum(emp => emp.Salary) > 20000
                              select new { UnitId = g.Key, TotalSalary = g.Sum(emp => emp.Salary) };

                foreach (var item in query12)
                {
                    Console.WriteLine($"UnitId: {item.UnitId}, Total Salary: {item.TotalSalary}");
                }

                // Problem Statement 13: Display the UnitId and total salary drawn by employees of job level 3 in each unit for all those units where the total salary of all JobLevel 3 employees is greater than 20000.
                var query13 = from emp in employeeList
                              where emp.JobLevel == 3
                              group emp by emp.UnitId into g
                              let totalSalaryJobLevel3 = g.Sum(emp => emp.Salary)
                              where totalSalaryJobLevel3 > 20000
                              select new { UnitId = g.Key, TotalSalaryJobLevel3 = totalSalaryJobLevel3 };

                foreach (var item in query13)
                {
                    Console.WriteLine($"UnitId: {item.UnitId}, Total Salary of JobLevel 3 employees: {item.TotalSalaryJobLevel3}");
                }

                // Problem Statement 14: Display the UnitName and maximum salary drawn by employees in each unit in descending order of maximum salary.
                var query14 = from emp in employeeList
                              join unit in unitList on emp.UnitId equals unit.UnitId
                              group emp by unit.UnitName into g
                              let maxSalary = g.Max(emp => emp.Salary)
                              orderby maxSalary descending
                              select new { UnitName = g.Key, MaxSalary = maxSalary };

                foreach (var item in query14)
                {
                    Console.WriteLine($"UnitName: {item.UnitName}, Maximum Salary: {item.MaxSalary}");
                }

                // Problem Statement 15: Display the EmployeeName, UnitId, Salary, and ProjectCode of those employees who draw the minimum salary in each unit.
                var query15 = from emp in employeeList
                              join unit in unitList on emp.UnitId equals unit.UnitId
                              group emp by emp.UnitId into g
                              let minSalary2 = g.Min(emp => emp.Salary)
                              from emp2 in g
                              where emp2.Salary == minSalary2
                              select new { emp2.EmployeeName, emp2.UnitId, emp2.Salary, emp2.ProjectCode };

                foreach (var emp in query15)
                {
                    Console.WriteLine($"EmployeeName: {emp.EmployeeName}, UnitId: {emp.UnitId}, Salary: {emp.Salary}, ProjectCode: {emp.ProjectCode}");
                }

                // Problem Statement 16: Display the EmployeeName, UnitName, Salary, and ProjectCode of those employees whose Salary is greater than the average salary in their unit.
                var query16 = from emp in employeeList
                              join unit in unitList on emp.UnitId equals unit.UnitId
                              group emp by new { unit.UnitId, unit.UnitName } into g
                              join emp2 in employeeList on g.Key.UnitId equals emp2.UnitId
                              let avgSalary = g.Average(e => e.Salary)
                              where emp2.Salary > avgSalary
                              select new { emp2.EmployeeName, g.Key.UnitName, emp2.Salary, emp2.ProjectCode };

                foreach (var emp in query16)
                {
                    Console.WriteLine($"EmployeeName: {emp.EmployeeName}, UnitName: {emp.UnitName}, Salary: {emp.Salary}, ProjectCode: {emp.ProjectCode}");
                }

                // Problem Statement 17: Display the UnitId, JobLevel, and number of employees in that unit and job level. (Hint: Group by unit id and job level)
                var query17 = from emp in employeeList
                              group emp by new { emp.UnitId, emp.JobLevel } into g
                              select new { g.Key.UnitId, g.Key.JobLevel, Count = g.Count() };

                foreach (var emp in query17)
                {
                    Console.WriteLine($"UnitId: {emp.UnitId}, JobLevel: {emp.JobLevel}, Number of employees: {emp.Count}");
                }

            }
        }


        public void LINQExcercise2(bool isQuerySyntax)
        {
            if (AccountsList == null)
                this.CreateAccounts();

            Operations operations = new Operations(isQuerySyntax);

            var accountList = AccountsList;

            // Test FetchCustomer method
            List<string> customersWithLowBalance = operations.FetchCustomer(accountList);
            Console.WriteLine("Customers with balance less than 1000:");
            foreach (string customer in customersWithLowBalance)
            {
                Console.WriteLine(customer);
            }

            // Test FetchCustomerInOrder method
            List<string> customerNamesInOrder = operations.FetchCustomerInOrder(accountList);
            Console.WriteLine("\nCustomer names in descending order of reward points:");
            foreach (string customer in customerNamesInOrder)
            {
                Console.WriteLine(customer);
            }

            // Test FetchAccountNumber method
            string vivekanandaAccountNumber = operations.FetchAccountNumber(accountList, "Vivekananda");
            Console.WriteLine($"\nAccount number of customer 'Vivekananda': {vivekanandaAccountNumber}");

            // Test FetchSumOfBalance method
            Dictionary<string, int> sumOfBalances = operations.FetchSumOfBalance(accountList);
            Console.WriteLine("\nTotal balance for each customer:");
            foreach (var kvp in sumOfBalances)
            {
                Console.WriteLine($"{kvp.Key}: {kvp.Value}");
            }

            // Test FetchNoOfAccount method
            int noOfSalaryAccounts = operations.FetchNoOfAccount(accountList, "Salary");
            Console.WriteLine($"\nNumber of accounts with type 'Salary': {noOfSalaryAccounts}");
        }

    }
}

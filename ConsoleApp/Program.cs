// See https://aka.ms/new-console-template for more information
//dotnet new -o MyLibrary . dotnet new sln -n "MySolution"
/*
Commands
- https://learn.microsoft.com/en-us/dotnet/core/tools/
- dotnet new gitignore
- dotnet new Sln
- dotnet new consoleapp -o ConsoleApp
- dotnet new classlib -o MyLibrary
- dotnet sln add ConsoleApp
- dotnet sln add MyLibrary  
- dotnet add app/app.csproj reference lib/lib.csproj
- dotnet add reference lib1/lib1.csproj lib2/lib2.csproj
- dotnet add package BenchmarkDotNet --version 0.13.2
- dotnet restore
*/


using System.Configuration;
using MyLib;
using MyLib.Employee;



string str= "hello";
var dt = new Dictionary<string,string>();
Console.WriteLine("Hello, World!");
CustomerCls custObj1= new CustomerCls();
custObj1.customerContact="12345671";
 CustomerCls custObj2 = new CustomerCls();
 CustomerCls custObj3;
 custObj2.Add(10.0,20);
custObj3 = custObj1;
custObj1 = null;
custObj3.customerAddress="Address";

custObj3.customerAddress = "outside";

NumberOfSeatsAndDoors x = new NumberOfSeatsAndDoors(5, 4);
        Car testCar1 = new Car("Audi", 20000, x);
        Car testCar2 = testCar1;

testCar2.manufacturer="skoda";

Console.WriteLine("end");

//ConfigTest();
//testMethod();
MethodOverridingTest();
DynamicMethodDispatchTest();

void DynamicMethodDispatchTest()
{
            Employee employee = new Employee();
            employee.BasicSalary = 10000;
            employee.EmployeeId = 1001;
            FinanceManagementDesk.PrintEmployeeDetails(employee);
            
            
            SystemsEngineer systemEngineer = new SystemsEngineer();
            systemEngineer.EmployeeId = 1002;
            systemEngineer.Incentive = 1000;
            systemEngineer.BasicSalary = 10000;
            // Observe the following line invokes the method which invokes GetTotalSalary() of the class systemEngineer
            FinanceManagementDesk.PrintEmployeeDetails(systemEngineer);
            
            TechnologyAnalyst technicalAnalyst = new TechnologyAnalyst();
            technicalAnalyst.EmployeeId = 1003;
            technicalAnalyst.companyBonus = 2050;
            technicalAnalyst.BasicSalary = 50000;
            // Observe the following line invokes the method which invokes GetTotalSalary() of the class technicalAnalyst 
            FinanceManagementDesk.PrintEmployeeDetails(technicalAnalyst);
}

void MethodOverridingTest()
{
    PrivilegedCustomer privilegedCustomer = new PrivilegedCustomer("Albert","9999999999","Albert@gmail.com","Churchgate road, Mumbai","Silver");
    Console.WriteLine("Privileged customer details are : " 
                + privilegedCustomer.GetCustomerDetails());

    RegularCustomer regularCustomer = new RegularCustomer("Frank", "8888888888", "Franken@gmail.com", "Central Park, Manhattan", 0.1);
    Console.WriteLine("Regular customer discount percentage is : " 
                + regularCustomer.GetDiscount());

        Parent parentOne = new Parent();
        Child child = new Child();
        Parent parentTwo = new Child();
        parentOne.Display();
        child.Display();
        parentTwo.Display(); //In this case, the child class method is called even though the reference is of parent class.Here, we have used the override keyword, therefore the child class's Display() method is invoked whenever there is an object of child class


        // Dynamic method dispatch
        Purchase purchase = new Purchase();
Console.WriteLine("Discount for privileged customer : " 
                + purchase.CalculateBillAmount(privilegedCustomer, 1000));
Console.WriteLine("Discount for regular customer : " 
                + purchase.CalculateBillAmount(regularCustomer, 1000));

}

void ConfigTest(){
          //string sectionName = "consoleSection";
  //ConsoleSection currentSection = null;
  
  // Get the roaming configuration 
  // that applies to the current user.
  Configuration roamingConfig =
    ConfigurationManager.OpenExeConfiguration(
     ConfigurationUserLevel.None);
     //roamingConfig

  // Map the roaming configuration file. This
  // enables the application to access 
  // the configuration file using the
  // System.Configuration.Configuration class
  ExeConfigurationFileMap configFileMap =
    new ExeConfigurationFileMap();
  configFileMap.ExeConfigFilename = @"/home/xfce/Desktop/DotNetCore/ConsoleApp/Example.config";


    // Get the mapped configuration file.
  Configuration config =
    ConfigurationManager.OpenMappedExeConfiguration(
      configFileMap, ConfigurationUserLevel.None);


      var productSettings = config.GetSection("ProductSettings") as ConfigurationExample.ProductSettings;
    if (productSettings == null)
    {
        Console.WriteLine("Product Settings are not defined");
    }
    else
    {
        var productNumber = productSettings.DellFeatures.ProductNumber;
        var productName = productSettings.DellFeatures.ProductName;
        var color = productSettings.DellFeatures.Color;
        var warranty = productSettings.DellFeatures.Warranty;

        Console.WriteLine("Product Number = " + productNumber);
        Console.WriteLine("Product Name = " + productName);
        Console.WriteLine("Product Color = " + color);
        Console.WriteLine("Product Warranty = " + warranty);
    }
}


void testMethod(){

double mobilePrice = 10000.00;
          short quantity = 10;             
          float discount = 5.00f;             
          double totalPrice = mobilePrice - (mobilePrice * discount / 100); 
          Console.WriteLine("Quantity = {0}  discount = {1} Total Price = {2}", quantity, discount, totalPrice);
    
        //     int sum = 0;
        //     for(int i=1;i<=10;i++)
        //     {
        //         if (i <= 5)
        //             continue;
        //         sum = sum + i;                
        //     }
        // Console.WriteLine("Sum={0}", sum);

        //     for (int i = 1; i <5;i++ )
        //     {
        //         for (int j = 1; j <= i; j++)
        //           Console.Write(j);
        //         Console.WriteLine();
        //     } 



            CustomerCls custObj1= new CustomerCls();
custObj1.customerContact="12345671";
//Customer custObj2 = new Customer();
custObj3 = custObj1;
//custObj1 = null;
custObj3.customerAddress="Address";

}








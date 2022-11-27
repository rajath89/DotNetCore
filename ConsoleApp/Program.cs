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


using MyLib;
string str= "hello";
var dt = new Dictionary<string,string>();
Console.WriteLine("Hello, World!");
// Customer custObj1= new Customer();
// custObj1.customerContact="12345671";
 Customer custObj2 = new Customer();
 Customer custObj3;
// Customer custObj3 = custObj1;
// custObj1 = null;
// custObj3.customerAddress="Address";

testMethod();

custObj3.customerAddress = "outside";

NumberOfSeatsAndDoors x = new NumberOfSeatsAndDoors(5, 4);
        Car testCar1 = new Car("Audi", 20000, x);
        Car testCar2 = testCar1;

testCar2.manufacturer="skoda";

Console.WriteLine("end");
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



            Customer custObj1= new Customer();
custObj1.customerContact="12345671";
//Customer custObj2 = new Customer();
custObj3 = custObj1;
//custObj1 = null;
custObj3.customerAddress="Address";
}




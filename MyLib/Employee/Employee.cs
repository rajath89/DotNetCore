using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLib.Employee
{

   public class Employee
    {
        public double BasicSalary { set; get; }
        public int EmployeeId { set; get; }
      
        public virtual double GetTotalSalary()
        {
            double hra = .15 * BasicSalary;
            double da = .10 * BasicSalary;
            double totalSalary = da + hra + BasicSalary;
            return totalSalary;
        }
    }
   public  class SystemsEngineer: Employee
    {
        public int Incentive { set; get; }
      
        public override double GetTotalSalary()
        {    
            double totalSalary = base.GetTotalSalary() + Incentive;
            return totalSalary;
        }

    }
    public class TechnologyAnalyst: Employee
    {
        public double companyBonus { set; get; }

        public override double GetTotalSalary()
        {   
            double totalSalary = base.GetTotalSalary() + companyBonus;
            return totalSalary;
        }
    }
    public class FinanceManagementDesk
    {
        public static void PrintEmployeeDetails(Employee employee)
        {
             // This method can receive object of type employee, SystemsEngineer or TechnologyAnalyst
             Console.WriteLine("Employee Id: " + employee.EmployeeId);
             /* Dynamic method dispatch is a mechanism by which a call to an overridden method is resolved at runtime. 
             Based on the type of the object received the corresponding method is invoked */
             //GetTotalSalary() is called based on the type of employee object  
             double totalSalary = employee.GetTotalSalary() - (0.3 * employee.GetTotalSalary());
             Console.WriteLine("Total Salary of Employee: " + totalSalary);
        }
    }
}
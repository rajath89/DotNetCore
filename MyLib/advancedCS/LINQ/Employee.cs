using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLib.advancedCS.LINQ
{
    public class Employee
    {
        // EmployeeId property to hold the incremented value
        private static int nextEmployeeId = 1000;
        public string EmployeeId { get; private set; }

        // Other existing properties
        public string EmployeeName { get; set; }
        public int UnitId { get; set; }
        public string ProjectCode { get; set; }
        public double Salary { get; set; }
        public int JobLevel { get; set; }
        public DateTime JoiningDate { get; set; }

        // Constructor to generate and assign EmployeeId
        public Employee()
        {
            EmployeeId = "E" + nextEmployeeId++;
        }
    }
}

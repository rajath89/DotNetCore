using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLib.advancedCS.Generics
{
    public class RequestQueue<T>
    {
        private T[] ListOfRequest;
        private int Pointer;

        public RequestQueue(int size)
        {
            ListOfRequest = new T[size];
            Pointer = 0;
        }

        public bool Add(T request)
        {
            if (Pointer < ListOfRequest.Length)
            {
                ListOfRequest[Pointer] = request;
                Pointer++;
                return true;
            }

            return false;
        }

        public bool ProcessItem()
        {
            if (Pointer > 0)
            {
                for (int i = 0; i < Pointer - 1; i++)
                {
                    ListOfRequest[i] = ListOfRequest[i + 1];
                }
                Pointer--;
                return true;
            }

            return false;
        }
    }

    public class Department
    {
        public bool RaiseRequest()
        {
            HelpDesk.DepQueue.Add(this);
            return true;
        }
    }

    public class Employee
    {
        public bool RaiseRequest()
        {
            HelpDesk.EmpQueue.Add(this);
            return true;
        }
    }

    public class HelpDesk
    {
        public static RequestQueue<Department> DepQueue;
        public static RequestQueue<Employee> EmpQueue;

        static HelpDesk()
        {
            DepQueue = new RequestQueue<Department>(100);
            EmpQueue = new RequestQueue<Employee>(10);
        }

        public bool ProcessDepRequest()
        {
            return DepQueue.ProcessItem();
        }

        public bool ProcessEmpRequest()
        {
            return EmpQueue.ProcessItem();
        }
    }

    public class GenericAssignment
    {
      public void TestGen()
      {
            // Test case
            HelpDesk helpDesk = new HelpDesk();

            Department department1 = new Department();
            Department department2 = new Department();
            department1.RaiseRequest();
            department2.RaiseRequest();

            Employee employee1 = new Employee();
            Employee employee2 = new Employee();
            employee1.RaiseRequest();
            employee2.RaiseRequest();

            Console.WriteLine("Department Requests Processed: " + helpDesk.ProcessDepRequest());
            Console.WriteLine("Employee Requests Processed: " + helpDesk.ProcessEmpRequest());
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLib
{
    public class Parent
    {
        public virtual void Display()
        {
            Console.WriteLine("Parent method");
        }
    }
    public class Child:Parent
    {
        public override void Display() //if new or ovveride is not added then warning says that the child's method hides the parent's method
        {
            Console.WriteLine("Child method");
        }
    }
}

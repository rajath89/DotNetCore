using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLib.advancedCS.LINQ
{
    public class Category
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        static int counter;
        static Category()
        {
            counter = 0;
        }
        public Category()
        {
            CategoryId = ++counter;
        }
        public Category(string categoryName) : this()
        {
            CategoryName = categoryName;
        }
    }
}

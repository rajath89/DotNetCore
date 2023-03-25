using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLib
{
    public class Esign
    {
        public string Name { get; set; }
        public string Address { get; set; }

        public Esign InstantiateObject()
        {
            this.Name = "EsignName";
            this.Address = "EsignAddress";

            return this;
        }
    }

    public class Esign2
    {
        public string Name { get; set; }

        public string Address { get; set; }
    }
}

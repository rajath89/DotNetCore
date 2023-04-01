using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLib.basicCS.Interface
{
    public interface ITax
    {
        double PayTax();
    }

    public interface IStateTax
    {
        double PayTax();
    }

}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeapotFactorio
{
    internal interface ISellable
    {
        double GetPrice();
        string GetName();
    }
}

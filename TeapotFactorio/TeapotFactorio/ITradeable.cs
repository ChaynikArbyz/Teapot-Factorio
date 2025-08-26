using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeapotFactorio
{
    internal interface ITradeable
    {
        void Buy(double quantity, double price);
        void Sell(double quantity, double price);
    }
}

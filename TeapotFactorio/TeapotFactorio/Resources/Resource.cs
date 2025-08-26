using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeapotFactorio.Resources
{
    internal abstract class Resource : ISellable
    {
        protected string name;
        protected double price;
        public double GetPrice() => price;

        public Resource(string name, double price)
        {
            this.name = name;
            this.price = price;
        }
        public string GetName() => name;
    }
}

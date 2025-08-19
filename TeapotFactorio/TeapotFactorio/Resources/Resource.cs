using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeapotFactorio.Resources
{
    internal abstract class Resource
    {
        protected string name;

        public Resource(string name)
        {
            this.name = name;
        }
        public string GetName() => name;
    }
}

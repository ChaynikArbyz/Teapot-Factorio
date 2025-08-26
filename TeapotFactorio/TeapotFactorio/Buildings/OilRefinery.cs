using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeapotFactorio.Resources;

namespace TeapotFactorio.Buildings
{
    internal class OilRefinery : Building
    {
        public OilRefinery(WareHouse wareHouse) : base(wareHouse, "Нафтопереробний завод", new Recipe(new Dictionary<Resource, double> { { new Oil(), 10 } }, new Dictionary<Resource, double> { { new Fuel(), 8 }, { new Plastic(), 2 } }), 11000, 5)
        {
            StartProduction();
        }
        public override string ToString()
        {
            return "Нафтопереробний завод";
        }
    }
}

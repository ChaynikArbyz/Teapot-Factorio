using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeapotFactorio.Resources;

namespace TeapotFactorio.Buildings
{
    internal class OilDrill : Building
    {
        public OilDrill(WareHouse wareHouse) : base(wareHouse, "Свердловина", new Recipe(new Dictionary<Resource, double> { }, new Dictionary<Resource, double> { { new Oil(), 2 } }), 8000, 3)
        {
            StartProduction();
        }
        public override string ToString()
        {
            return "Свердловина";
        }
    }
}

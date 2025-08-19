using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeapotFactorio.Resources;

namespace TeapotFactorio.Buildings
{
    internal class CoalMine : Building
    {
        public CoalMine(WareHouse wareHouse) : base("Вугільна шахта", new Recipe(new Dictionary<Resource, double> { }, new Dictionary<Resource, double> { { new Coal(), 1 } }), 8000)
        {
            StartProduction(wareHouse);
        }
        public override string ToString()
        {
            return "Вугільна шахта";
        }
    }
}

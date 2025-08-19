using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeapotFactorio.Resources;

namespace TeapotFactorio.Buildings
{
    internal class OreMine : Building
    {
        public OreMine(WareHouse wareHouse) : base("Рудна шахта", new Recipe(new Dictionary<Resource, double> { }, new Dictionary<Resource, double> { { new Ore(), 2 } }),8000)
        {
            StartProduction(wareHouse);
        }
        public override string ToString()
        {
            return "Рудна шахта";
        }
    }
}

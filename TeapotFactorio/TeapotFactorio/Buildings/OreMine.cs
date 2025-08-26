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
        public OreMine(WareHouse wareHouse) : base(wareHouse,"Рудна шахта", new Recipe(new Dictionary<Resource, double> { }, new Dictionary<Resource, double> { { new Ore(), 2 } }),8000, 0)
        {
            StartProduction();
        }
        public override string ToString()
        {
            return "Рудна шахта";
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeapotFactorio.Resources;

namespace TeapotFactorio.Buildings
{
    internal class SteelWorks : Building
    {
        public SteelWorks(WareHouse wareHouse) : base(wareHouse,"Сталеливарний завод", new Recipe(new Dictionary<Resource, double> { { new Ore(), 10 } }, new Dictionary<Resource, double> { { new Iron(), 8 }, { new Cooper(), 1 }, { new Lead(), 1 } }), 12000, 6)
        {
            StartProduction();
        }
        public override string ToString()
        {
            return "Сталеливарний завод";
        }
    }
}

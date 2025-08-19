using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeapotFactorio.Resources;

namespace TeapotFactorio.Buildings
{
    internal class ElectricStation : Building
    {
        public ElectricStation(WareHouse wareHouse) : base("Електро Станція", new Recipe(new Dictionary<Resource, double> { { new Coal(), 1 } }, new Dictionary<Resource, double> { { new ElectroEnergy(), 10 } }), 7000)
        {
            StartProduction(wareHouse);
        }
        public override string ToString()
        {
            return "ЕлектроСтанція";
        }
    }
}

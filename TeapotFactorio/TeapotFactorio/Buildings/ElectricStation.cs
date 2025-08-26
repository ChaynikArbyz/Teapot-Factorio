using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ColorTextService;
using TeapotFactorio.Resources;

namespace TeapotFactorio.Buildings
{
    internal class ElectricStation : Building
    {
        bool isProducing = false;
        public ElectricStation(WareHouse wareHouse) : base(wareHouse, "Електро Станція", new Recipe(new Dictionary<Resource, double> { { new Coal(), 1 } }, new Dictionary<Resource, double> { { new ElectroEnergy(), 10 } }), 7000, 0)
        {
            StartProduction();
        }

        private void notProduce(WareHouse wareHouse)
        {
            if (isProducing)
            {
                isProducing = false;
                foreach (var output in recipe.OutputResources)
                {
                    wareHouse.RemoveResource(output.Key, output.Value);
                }
            }
        }

        public void StopProductionElectrocity(WareHouse wareHouse)
        {
            base.StopProduction();
            notProduce(wareHouse);
        }

        protected override void Produce(WareHouse wareHouse)
        {
            foreach (var input in recipe.InputResources)
            {
                if (!wareHouse.resources.ContainsKey(input.Key.GetName()) || wareHouse.resources[input.Key.GetName()] < input.Value)
                {
                    notProduce(wareHouse);
                    ColorText.WriteColorLine($"Недостатньо ресурсів для виробництва {name}", ConsoleColor.DarkRed);
                    return;
                }
            }
            foreach (var input in recipe.InputResources)
            {
                wareHouse.RemoveResource(input.Key, input.Value);
            }
            foreach (var output in recipe.OutputResources)
            {
                if (!isProducing)
                {
                    isProducing = true;
                    wareHouse.AddResource(output.Key, output.Value);
                }
            }
        }

        public override string ToString()
        {
            return "ЕлектроСтанція";
        }
    }
}

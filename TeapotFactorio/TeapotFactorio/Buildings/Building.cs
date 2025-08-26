using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using ColorTextService;
using TeapotFactorio.Resources;

namespace TeapotFactorio.Buildings
{
    internal abstract class Building
    {
        public string name { get; private set; }
        protected int energyConsumption;
        protected int timeToProduce;
        protected Recipe recipe;
        protected Timer timer;
        protected WareHouse _wareHouse;

        public Building(WareHouse wareHouse,string name, Recipe recipe, int timeToProduceInMilisec, int energyConsumption)
        {
            this._wareHouse = wareHouse ?? throw new ArgumentNullException(nameof(wareHouse), "Склад не може бути нічим");
            this.name = name;
            this.recipe = recipe;
            this.timeToProduce = timeToProduceInMilisec;
            this.energyConsumption = energyConsumption;
        }

        public void StartProduction()
        {
            _wareHouse.AddResource(new ElectroEnergyUsage(), energyConsumption);
            timer = new Timer(timeToProduce);
            timer.Elapsed += (sender, e) => Produce(_wareHouse);
            timer.AutoReset = true;
            timer.Enabled = true;
        }

        public void StopProduction()
        {
            _wareHouse.RemoveResource(new ElectroEnergyUsage(), energyConsumption);
            if (timer != null)
            {
                timer.Stop();
                timer.Dispose();
                timer = null;
            }
        }

        protected virtual void Produce(WareHouse wareHouse)
        {
            if (energyConsumption > 0)
            {  
                ElectroEnergy electroTemplate = new ElectroEnergy();
                if (wareHouse.resources.ContainsKey(electroTemplate.GetName()))
                {
                    if (wareHouse.resources[electroTemplate.GetName()] < wareHouse.resources[new ElectroEnergyUsage().GetName()])
                    {
                        ColorText.WriteColorLine("Недостатньо єлектроенергії для виробництва!", ConsoleColor.DarkRed);
                        return;
                    }
                }
                else
                {
                    ColorText.WriteColorLine("Відсутня єлектроенергія, потрібна електро станція!", ConsoleColor.DarkRed);
                    return;
                }
            }


            foreach (var input in recipe.InputResources)
            {
                if (!wareHouse.resources.ContainsKey(input.Key.GetName()) || wareHouse.resources[input.Key.GetName()] < input.Value)
                {

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
                wareHouse.AddResource(output.Key, output.Value);
            }
        }

        public void ChangeRecipe(Recipe newRecipe)
        {
            if (newRecipe == null){ throw new ArgumentNullException(nameof(newRecipe), "рецепт не може бути нічим"); };
            this.recipe = newRecipe;
        }
    }
}

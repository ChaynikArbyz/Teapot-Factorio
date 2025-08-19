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
        protected int timeToProduce;
        protected Recipe recipe;
        protected Timer timer;
        protected WareHouse _wareHouse;

        public Building(string name, Recipe recipe, int timeToProduceInMilisec)
        {
            this.name = name;
            this.recipe = recipe;
            this.timeToProduce = timeToProduceInMilisec;
        }

        public void StartProduction(WareHouse wareHouse)
        {
            _wareHouse = wareHouse ?? throw new ArgumentNullException(nameof(wareHouse), "Склад не може бути нічим");
            timer = new Timer(timeToProduce);
            timer.Elapsed += (sender, e) => Produce(_wareHouse);
            timer.AutoReset = true;
            timer.Enabled = true;
        }

        public void StopProduction()
        {
            if (timer != null)
            {
                timer.Stop();
                timer.Dispose();
                timer = null;
            }
        }

        protected void Produce(WareHouse wareHouse)
        {
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

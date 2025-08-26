using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ColorTextService;
using TeapotFactorio.AdvancedResources;
using TeapotFactorio.Resources;

namespace TeapotFactorio.Buildings
{
    internal class TheMainPlantForEverything : Building
    {
        private Recipes AdvancedRecipes = new Recipes();
        public TheMainPlantForEverything(WareHouse wareHouse) : base(wareHouse,"Головний завод для всього", new Recipe(new Dictionary<Resource, double> { { new ElectroEnergy(), 5 }, { new Iron(), 2 }, { new Cooper(), 1 }, { new Plastic(), 3 } }, new Dictionary<Resource, double> { { new Teapot(), 1 } }), 25000, 10)
        {
            StartProduction();
            AdvancedRecipes.AddRecipe("Чайник", new Recipe(new Dictionary<Resource, double> { { new ElectroEnergy(), 5 }, { new Iron(), 2 }, { new Cooper(), 1 }, { new Plastic(), 3 } }, new Dictionary<Resource, double> { { new Teapot(), 1 } }));
            AdvancedRecipes.AddRecipe("Чашка", new Recipe(new Dictionary<Resource, double> { { new Iron(), 2 }, { new Plastic(), 5 } }, new Dictionary<Resource, double> { { new Cup(), 1 } }));
            AdvancedRecipes.AddRecipe("Годинник", new Recipe(new Dictionary<Resource, double> { { new Iron(), 3 }, { new Plastic(), 4 }, { new ElectroEnergy(), 3 }, { new Cooper(), 1 } }, new Dictionary<Resource, double> { { new Clock(), 1 } }));
            AdvancedRecipes.AddRecipe("Розетка", new Recipe(new Dictionary<Resource, double> { { new Cooper(), 2 }, { new Plastic(), 8 }, { new ElectroEnergy(), 5 } }, new Dictionary<Resource, double> { { new Socket(), 1 } }));
            AdvancedRecipes.AddRecipe("Холодильник", new Recipe(new Dictionary<Resource, double> { { new Iron(), 10 }, { new Plastic(), 7 }, { new Cooper(), 4 }, { new ElectroEnergy(), 3 }, { new Fuel(), 1 }, { new Lead(), 2 } }, new Dictionary<Resource, double> { { new Fridge(), 1 } }));
        }

        public void ShowAndChooseRecipe()
        {
            ColorText.WriteColorLine("напишіть предмет який буде виготовлятися:", ConsoleColor.Yellow);
            foreach (var kvp in AdvancedRecipes.recipes)
            {
                Console.WriteLine(kvp.Key);
            }
            string input = Console.ReadLine();
            if (AdvancedRecipes.recipes.ContainsKey(input))
            {
                ColorText.WriteColorLine($"Ви обрали рецепт: {input}", ConsoleColor.Green);
                ChangeRecipe(AdvancedRecipes.recipes[input]);
            }
            else 
            {
                ColorText.WriteColorLine("Не існуючий предмет!", ConsoleColor.Red);
            }
        }

        public override string ToString()
        {
            return "Головний завод для всього";
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeapotFactorio
{
    internal class Recipes
    {
        public Dictionary<string, Recipe> recipes { get; private set; }

        public Recipes()
        {
            recipes = new Dictionary<string, Recipe> { };
        }

        public void AddRecipe(string name, Recipe recipe)
        {
            if (string.IsNullOrEmpty(name) || recipe == null) { return; }
            if (recipes.ContainsKey(name)) { return; }
            recipes.Add(name, recipe);
        }
        public void RemoveRecipe(string name)
        {
            if (string.IsNullOrEmpty(name) || !recipes.ContainsKey(name)) { return; }
            recipes.Remove(name);
        }

        public Recipe GetRecipe(string name)
        {
            if (string.IsNullOrEmpty(name) || !recipes.ContainsKey(name)) { return null; }
            return recipes[name];
        }
    }
}

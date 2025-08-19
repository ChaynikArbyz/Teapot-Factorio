using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeapotFactorio.Resources;

namespace TeapotFactorio
{
    internal class Recipe
    {
        public Dictionary<Resource, double> InputResources { get; private set; }
        public Dictionary<Resource, double> OutputResources { get; private set; }

        public Recipe(Dictionary<Resource, double> inputResources, Dictionary<Resource, double> outputResources)
        {
            this.InputResources = inputResources;
            this.OutputResources = outputResources;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("-------- Рецепт --------");
            sb.AppendLine("  -> Вхідні ресурси -<");
            if (InputResources.Count == 0)
            {
                sb.AppendLine("немає");
            }
            else
            {
                foreach (var kvp in InputResources)
                {
                    sb.AppendLine($"{kvp.Key.GetName()}: {kvp.Value}");
                }
            }
            sb.AppendLine(" -> Вихідні ресурси -<");
            if (OutputResources.Count == 0)
            {
                sb.AppendLine("немає");
            }
            else
            {
                foreach (var kvp in OutputResources)
                {
                    sb.AppendLine($"{kvp.Key.GetName()}: {kvp.Value}");
                }
            }
            sb.AppendLine("------------------------");
            return sb.ToString();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeapotFactorio.Resources;

namespace TeapotFactorio.Buildings
{
    internal class WareHouse
    {
        public Dictionary<string, double> resources { get; private set; }
        private readonly object _lock = new object();

        public WareHouse()
        {
            resources = new Dictionary<string, double>();
        }
        public void AddResource(Resource resource, double amount)
        {
            if (amount <= 0) { return; }

            lock (_lock)
            {
                if (resources.ContainsKey(resource.GetName()))
                {
                    resources[resource.GetName()] += amount;
                }
                else
                {
                    resources[resource.GetName()] = amount;
                }
            }
        }

        public void RemoveResource(Resource resource, double amount)
        {
            if (amount <= 0 || !resources.ContainsKey(resource.GetName())) { return; }

            lock (_lock)
            {
                if (resources[resource.GetName()] >= amount)
                {
                    resources[resource.GetName()] -= amount;
                }
            }
        }
        public override string ToString()
        {
            lock (_lock)
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendLine("------- Склад -------");
                if (resources.Count() <= 0)
                {
                    sb.AppendLine("        пусто");
                    sb.AppendLine("---------------------");
                    return sb.ToString();
                }
                ElectroEnergy energyTemplate = new ElectroEnergy();
                ElectroEnergyUsage energyUsageTemplate = new ElectroEnergyUsage();
                foreach (var kvp in resources)
                {
                    if (kvp.Key == energyUsageTemplate.GetName() || kvp.Key == energyTemplate.GetName())
                    { continue; }
                    sb.AppendLine($"{kvp.Key}: {kvp.Value}");
                }
                sb.AppendLine("---------------------");
                if (resources.ContainsKey(energyTemplate.GetName()))
                {
                    if (resources.ContainsKey(energyUsageTemplate.GetName()))
                        sb.AppendLine($"Споживання електроєнергії: {resources[energyUsageTemplate.GetName()]}/{resources[energyTemplate.GetName()]} кВт");
                }
                return sb.ToString();
            }
        }
    }
}

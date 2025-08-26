
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ColorTextService;
using TeapotFactorio.Buildings;
using TeapotFactorio.Resources;

namespace TeapotFactorio
{
    internal class Concern
    {

        public string name;
        public double cash { get; private set; } = 0;
        public void AddMoney(double amount) 
        {
            if (amount  + cash < 0) { return; }
            cash += amount;
        }
        public WareHouse wareHouse { get; private set; }
        public List<Building> buildings { get; private set; }

        public Concern(string name) 
        {
            this.name = name;
            wareHouse = new WareHouse();
            buildings = new List<Building>();
        }

        private void AddBuilding(Building building)
        {
            buildings.Add(building);
        }

        public void CreateNewBuilding() //Мега Костиль
        { 
            ColorText.WriteColorLine("Виберіть виробництво:", ConsoleColor.Yellow);
            Console.WriteLine("1.Вугільна шахта");
            Console.WriteLine("2.Рудна шахта");
            Console.WriteLine("3.Свердловина");
            Console.WriteLine("4.Електростанція");
            Console.WriteLine("5.Сталеливарний завод");
            Console.WriteLine("6.Нафтопереробний завод");
            Console.WriteLine("7.Головний завод для всього");
            Console.WriteLine("esc.Назад");
            ConsoleKey input = Console.ReadKey().Key;
            Console.WriteLine("\n");
            switch (input)
            {
                case ConsoleKey.D1:
                    ColorText.WriteColorLine("Успішно!", ConsoleColor.Green);
                    AddBuilding(new CoalMine(wareHouse));
                    break;
                case ConsoleKey.D2:
                    ColorText.WriteColorLine("Успішно!", ConsoleColor.Green);
                    AddBuilding(new OreMine(wareHouse));
                    break;
                case ConsoleKey.D3:
                    ColorText.WriteColorLine("Успішно!", ConsoleColor.Green);
                    AddBuilding(new OilDrill(wareHouse));
                    break;
                case ConsoleKey.D4:
                    ColorText.WriteColorLine("Успішно!", ConsoleColor.Green);
                    AddBuilding(new ElectricStation(wareHouse));
                    break;
                case ConsoleKey.D5:
                    ColorText.WriteColorLine("Успішно!", ConsoleColor.Green);
                    AddBuilding(new SteelWorks(wareHouse));
                    break;
                case ConsoleKey.D6:
                    ColorText.WriteColorLine("Успішно!", ConsoleColor.Green);
                    AddBuilding(new OilRefinery(wareHouse));
                    break;
                case ConsoleKey.D7:
                    for (int i = 0; i < buildings.Count(); i++)
                    {
                        if (buildings[i] is TheMainPlantForEverything)
                        {
                            ColorText.WriteColorLine("Головний завод може бути лише 1", ConsoleColor.Red);
                            return;
                        }
                    }
                    ColorText.WriteColorLine("Успішно!", ConsoleColor.Green);
                    AddBuilding(new TheMainPlantForEverything(wareHouse));
                    break;
                case ConsoleKey.Escape:
                    return;
                default:
                    ColorText.WriteColorLine("Невірний ввід!", ConsoleColor.Red);
                    break;
            }

        }

        public void ShowAllBuildings() 
        {
            if (buildings.Count == 0) { ColorText.WriteColorLine("У вас немає виробництв", ConsoleColor.DarkGray); return; }
            Dictionary<string, int> count = new Dictionary<string, int> { };
            foreach (Building building in buildings) 
            {
                if (count.ContainsKey(building.ToString()))
                { count[building.ToString()]++; }
                else { count[building.ToString()] = 1; }
            }
            foreach (var kvp in count)
            {
                Console.WriteLine(kvp.Key + ": " + kvp.Value);
            }
        }
    }
}

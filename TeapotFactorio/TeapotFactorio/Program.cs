using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using ColorTextService;
using TeapotFactorio.AdvancedResources;
using TeapotFactorio.Buildings;
using TeapotFactorio.Resources;

namespace TeapotFactorio
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.Unicode;
            Console.InputEncoding = Encoding.Unicode;

            Concern concern = new Concern("Фабрика великих чайників");

            bool isRunning = true;
            bool isFalseInput = false;

            while (isRunning)
            {
                Console.Clear();

                if (isFalseInput)
                {
                    ColorText.WriteColorLine("Невірний вибір, спробуйте ще раз\n", ConsoleColor.Red);
                    isFalseInput = false;
                }

                ColorText.WriteColorLine("-< Teapot Factorio >-\n", ConsoleColor.Red);
                Console.WriteLine(concern.wareHouse.ToString());
                Console.WriteLine("Виберіть дію:");
                Console.WriteLine("1. Створити нове виробництво");
                Console.WriteLine("2. Список всіх виробництв");
                Console.WriteLine("3. Змінити головний продукт виготовлення");
                Console.WriteLine("4. Оновити меню");
                Console.WriteLine("esc. Вийти");

                switch (Console.ReadKey(true).Key)
                {
                    case ConsoleKey.D1:
                        Console.Clear();
                        concern.CreateNewBuilding();
                        Console.WriteLine("\nНатисніть будь-яку клавішу для повернення до головного меню...");
                        Console.ReadKey(true);
                        break;
                    case ConsoleKey.D2:
                        Console.Clear();
                        concern.ShowAllBuildings();
                        Console.WriteLine("\nНатисніть будь-яку клавішу для повернення до головного меню...");
                        Console.ReadKey(true);
                        break;
                    case ConsoleKey.D3:
                        Console.Clear();
                        bool find = false;
                        for (int i = 0; i < concern.buildings.Count(); i++)
                        {
                            if (concern.buildings[i] is TheMainPlantForEverything mainPlant)
                            {
                                mainPlant.ShowAndChooseRecipe();
                                find = true;
                            }
                        }
                        if (!find) { ColorText.WriteColorLine("У вас немає головного заводу для данної дії!", ConsoleColor.Red); }
                        Console.WriteLine("\nНатисніть будь-яку клавішу для повернення до головного меню...");
                        Console.ReadKey(true);
                        break;
                    case ConsoleKey.D4:
                        break;
                    case ConsoleKey.Escape:
                        isRunning = false;
                        return;
                    default:
                        isFalseInput = true;
                        break;
                }
            }


        }
    }
}

using System;
using System.Linq;
using System.Text;
using ColorTextService;
using TeapotFactorio.Buildings;

namespace TeapotFactorio
{
    internal class Program
    {
        static void Main(string[] args)
        {


            //без автопокупки і автопродажу, із-за структури коду, якщо автопокупку ще можна зробити з доп костилями то для автопродажу треба міняти весь код з таймерів на такти



            Console.OutputEncoding = Encoding.Unicode;
            Console.InputEncoding = Encoding.Unicode;

            Concern concern = new Concern("Фабрика великих чайників");
            MarketPlace marketPlace = new MarketPlace(concern);

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
                Console.Write(concern.wareHouse.ToString());
                ColorText.WriteColorLine("Гроші: " + concern.cash + "$\n", ConsoleColor.DarkYellow);
                Console.WriteLine("Виберіть дію:");
                Console.WriteLine("1. Створити нове виробництво");
                Console.WriteLine("2. Список всіх виробництв");
                Console.WriteLine("3. Змінити головний продукт виготовлення");
                Console.WriteLine("4. Маркетплейс");
                Console.WriteLine("5. Оновити меню");
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
                        marketPlace.ShowMarketWindow();
                        break;
                    case ConsoleKey.D5:
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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ColorTextService;
using TeapotFactorio.AdvancedResources;
using TeapotFactorio.Resources;
using System.Timers;

namespace TeapotFactorio
{
    internal class MarketPlace
    {
        private Concern _concern;
        private Timer timer;

        List<MarketResource> marketResources = new List<MarketResource> //костиль 
        {
            new MarketResource(new Coal()),
            new MarketResource(new Cooper()),
            new MarketResource(new Fuel()),
            new MarketResource(new Iron()),
            new MarketResource(new Lead()),
            new MarketResource(new Oil()),
            new MarketResource(new Ore()),
            new MarketResource(new Plastic()),
            new MarketResource(new Clock()),
            new MarketResource(new Cup()),
            new MarketResource(new Fridge()),
            new MarketResource(new Socket()),
            new MarketResource(new Teapot()),
        };
        public MarketPlace(Concern concern)
        {
            _concern = concern ?? throw new ArgumentNullException(nameof(concern), "Підприємство не може бути нічим");
            timer = new Timer(10000);
            timer.Elapsed += (sender, e) => DecreaseAllMarketResourcesBuyCount();
            timer.AutoReset = true;
            timer.Enabled = true;
        }

        private void DecreaseAllMarketResourcesBuyCount() 
        {
        foreach (var item in marketResources)
            {
                item.ChangeBuyCount(-1);
            }
        }

        public void ShowMarketWindow()
        {
            bool isRunning = true;
            bool isFalseInput = false;
            while (isRunning)
            {
                Console.Clear();
                if (isFalseInput)
                {
                    ColorTextService.ColorText.WriteColorLine("Невірний вибір, спробуйте ще раз\n", ConsoleColor.Red);
                    isFalseInput = false;
                }
                ColorTextService.ColorText.WriteColorLine("-< MarketPlace >-\n", ConsoleColor.Red);
                ColorText.WriteColorLine("Гроші: " + _concern.cash + "$", ConsoleColor.DarkYellow);
                Console.WriteLine("Виберіть дію:");
                Console.WriteLine("1. Купити ресурс");
                Console.WriteLine("2. Продати ресурс");
                Console.WriteLine("esc. Назад");
                ColorText.WriteColorLine("\nЗа кожен купленний товар додається націнка, кожні 10 секунд націнка спадає на 1", ConsoleColor.DarkGray);
                switch (Console.ReadKey(true).Key)
                {
                    case ConsoleKey.D1:
                        Console.Clear();
                        ShowAllMarketResources();
                        Console.WriteLine("\nВпишіть ресурс для купівлі:");
                        string resourceToBuy = Console.ReadLine();
                        int indexToBuy = -1;
                        for (int i = 0; i < marketResources.Count; i++)
                        {
                            if (marketResources[i].resource.GetName() == resourceToBuy)
                            {
                                indexToBuy = i;
                                break;
                            }
                        }
                        if (indexToBuy != -1)
                        {
                            Console.WriteLine("Впишіть кількість для купівлі:");
                            if (double.TryParse(Console.ReadLine(), out double quantityToBuy) && quantityToBuy > 0)
                            {
                                marketResources[indexToBuy].ChangeBuyCount(quantityToBuy);
                                BuyResource(marketResources[indexToBuy].resource, quantityToBuy);
                                ColorTextService.ColorText.WriteColorLine("Успішно!", ConsoleColor.Green);
                            }
                            else
                            {
                                ColorTextService.ColorText.WriteColorLine("Невірна кількість!", ConsoleColor.Red);
                            }
                        }
                        else
                        {
                            ColorTextService.ColorText.WriteColorLine("Ресурс не знайдено!", ConsoleColor.Red);
                        }
                        Console.WriteLine("\nНатисніть будь-яку клавішу для повернення до головного меню...");
                        Console.ReadKey(true);
                        break;
                    case ConsoleKey.D2:
                        Console.Clear();
                        ShowAllOwnedResources();
                        Console.WriteLine("\nВпишіть ресурс для продажі:");
                        string resourceToSell = Console.ReadLine();
                        int indexToSell = -1;
                        for (int i = 0; i < marketResources.Count; i++)
                        {
                            if (marketResources[i].resource.GetName() == resourceToSell)
                            {
                                indexToSell = i;
                                break;
                            }
                        }
                        if (indexToSell != -1)
                        {
                            Console.WriteLine("Впишіть кількість для продажі:");
                            if (double.TryParse(Console.ReadLine(), out double quantityToSell) && quantityToSell > 0)
                            {
                                SellResource(marketResources[indexToSell].resource, quantityToSell);
                                ColorTextService.ColorText.WriteColorLine("Успішно!", ConsoleColor.Green);
                            }
                            else
                            {
                                ColorTextService.ColorText.WriteColorLine("Невірна кількість!", ConsoleColor.Red);
                            }
                        }
                        else
                        {
                            ColorTextService.ColorText.WriteColorLine("Ресурс не знайдено!", ConsoleColor.Red);
                        }
                        Console.WriteLine("\nНатисніть будь-яку клавішу для повернення до головного меню...");
                        Console.ReadKey(true);
                        break;
                    case ConsoleKey.Escape:
                        isRunning = false;
                        break;
                    default:
                        isFalseInput = true;
                        break;
                }
            }
        }

        public void ShowAllOwnedResources()
        {
            Console.WriteLine("Ваші ресурси:");
            foreach (var item in _concern.wareHouse.resources)
            {
                for (int i = 0; i < marketResources.Count; i++)
                {
                    if (marketResources[i].resource.GetName() == item.Key)
                    {
                        Console.WriteLine($"{item.Key} - {item.Value}");
                    }
                }
            }
        }

        public void ShowAllMarketResources()
        {
            Console.WriteLine("Доступні ресурси на ринку:");
            foreach (var item in marketResources)
            {
                Console.WriteLine($"{item.resource.GetName()} - {item.price}$");
            }
        }
        public void BuyResource(ISellable sellable, double quantity)
        {


            if (sellable is Resource resource)
            {
                double totalPrice = sellable.GetPrice() * quantity;
                if (_concern.cash >= totalPrice)
                {
                    _concern.AddMoney(-totalPrice);
                    _concern.wareHouse.AddResource(resource, quantity);
                }
                else
                {
                    ColorTextService.ColorText.WriteColorLine("Неможна купити не ресурс!", ConsoleColor.Red);
                }
            }
            else
            {
                ColorTextService.ColorText.WriteColorLine("Недостатньо грошей!", ConsoleColor.Red);
            }
        }
        public void SellResource(ISellable sellable, double quantity)
        {
            if (sellable is Resource resource)
            {
                double totalPrice = sellable.GetPrice() * quantity;
                _concern.wareHouse.RemoveResource(resource, quantity);
                _concern.AddMoney(totalPrice);
            }
            else
            {
                ColorTextService.ColorText.WriteColorLine("Неможна продати не ресурс!", ConsoleColor.Red);
            }
        }
    }
}

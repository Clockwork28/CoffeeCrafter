using CoffeeCrafter.Beverages;
using CoffeeCrafter.Decorators;
using CoffeeCrafter.Interfaces;
using CoffeeCrafter.OrderSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeCrafter.Factory
{
    internal class CoffeeFactory
    {
        public async Task<IBeverage> Make(OrderDTO order)
        {
            return await (order.type.ToLowerInvariant() switch
            {
                "espresso" => HandleExtra(new Espresso(5M), order.id, order.extras),
                "americano" => HandleExtra(new Americano(7M), order.id, order.extras),
                "cappuccino" => HandleExtra(new Cappuccino(9M), order.id, order.extras),
                "latte" => HandleExtra(new Latte(10M), order.id, order.extras),
                _ => throw new ArgumentException($"Invalid coffee type!")
            });
        }
        public async Task<IBeverage> HandleExtra(IBeverage beverage, int id, string[] extras)
        {
            var extrasSet = extras.Select(x => x.ToLowerInvariant()).ToHashSet();
            if (extrasSet.Contains("milk"))
                beverage = new MilkDecorator(beverage);

            if (extrasSet.Contains("cream"))
                beverage = new WhippedCreamDecorator(beverage);

            if (extrasSet.Contains("syrup"))
                beverage = new SyrupDecorator(beverage);
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.Write($"[ID: {id}] ");
            Console.ResetColor();
            Console.Write($"Making {beverage.GetDescription()}\n");
            await Task.Delay(beverage.PrepTime);
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write($"[ID: {id}] ");
            Console.ResetColor();
            Console.Write($"{beverage.GetDescription()} is ready!\n");

            return beverage;
           
        }
    }
}

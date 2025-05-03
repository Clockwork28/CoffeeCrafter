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
        public async Task<IBeverage> Make(OrderDTO order, CancellationToken token)
        {
            return await (order.type.ToLowerInvariant() switch
            {
                "espresso" => HandleExtra(new Espresso(5M), order.status, order.id, order.extras, token),
                "americano" => HandleExtra(new Americano(7M), order.status, order.id, order.extras, token),
                "cappuccino" => HandleExtra(new Cappuccino(9M), order.status, order.id, order.extras, token),
                "latte" => HandleExtra(new Latte(10M), order.status, order.id, order.extras, token),
                _ => throw new ArgumentException($"Invalid coffee type!")
            });
        }
        public async Task<IBeverage> HandleExtra(IBeverage beverage, string status, int id, string[] extras, CancellationToken token)
        {
            var extrasSet = extras.Select(x => x.ToLowerInvariant()).ToHashSet();
            if (extrasSet.Contains("milk"))
                beverage = new MilkDecorator(beverage);

            if (extrasSet.Contains("cream"))
                beverage = new WhippedCreamDecorator(beverage);

            if (extrasSet.Contains("syrup"))
                beverage = new SyrupDecorator(beverage);
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.Write($"[ID: {id}] [{status[0]}] ");
            Console.ResetColor();
            Console.Write($"Making {beverage.GetDescription()}\n");
            await Task.Delay(beverage.PrepTime, token);
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write($"[ID: {id}] [{status[0]}] ");
            Console.ResetColor();
            Console.Write($"{beverage.GetDescription()} is ready!\n");

            return beverage;
           
        }
    }
}

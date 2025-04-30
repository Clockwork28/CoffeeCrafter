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
            await (order.type.ToLowerInvariant() switch
            {
                "espresso" => HandleExtra(new Espresso(5M), order.id, order.extras),
                "americano" => HandleExtra(new Americano(7M), order.id, order.extras),
                "cappuccino" => HandleExtra(new Cappuccino(9M), order.id, order.extras),
                "latte" => HandleExtra(new Latte(10M), order.id, order.extras),
                _ => throw new ArgumentException($"{Console.ForegroundColor = ConsoleColor.Red}Invalid coffee type!{Console.ResetColor}")
            });
            return null!;
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

            Console.WriteLine($"{Console.ForegroundColor = ConsoleColor.DarkBlue}[{id}] {Console.ResetColor}Making {beverage.GetDescription()}");
            await Task.Delay(beverage.PrepTime);
            Console.WriteLine($"{Console.ForegroundColor = ConsoleColor.DarkBlue}[{id}] {Console.ResetColor}{beverage.GetDescription} is ready!");

            return beverage;
           
        }
    }
}

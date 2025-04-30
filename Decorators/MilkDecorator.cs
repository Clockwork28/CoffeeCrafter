using CoffeeCrafter.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeCrafter.Decorators
{
    internal class MilkDecorator : IBeverage
    {
        protected IBeverage _beverage { get; set; }
        public int PrepTime { get; init; }

        public MilkDecorator(IBeverage beverage)
        {
            _beverage = beverage;
            PrepTime = _beverage.PrepTime + 200;
        }
        public decimal GetCost()
        {
            return _beverage.GetCost() + 0.5M;
        }

        public string GetDescription()
        {
            return _beverage.GetDescription() + " with extra milk";
        }
    }
}

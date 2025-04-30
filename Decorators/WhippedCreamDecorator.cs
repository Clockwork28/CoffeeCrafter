using CoffeeCrafter.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeCrafter.Decorators
{
    internal class WhippedCreamDecorator : IBeverage
    {
        protected IBeverage _beverage { get; set; }
        public int PrepTime { get; init; }

        public WhippedCreamDecorator(IBeverage beverage)
        {
            _beverage = beverage;
            PrepTime = _beverage.PrepTime + 450;
        }
        public decimal GetCost()
        {
            return _beverage.GetCost() + 1.2M;
        }

        public string GetDescription()
        {
            return _beverage.GetDescription() + " with extra whipped cream";
        }
    }
}

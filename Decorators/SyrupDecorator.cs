using CoffeeCrafter.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeCrafter.Decorators
{
    internal class SyrupDecorator : IBeverage
    {
        protected IBeverage _beverage { get; set; }
        public int PrepTime { get; init; }

        public SyrupDecorator(IBeverage beverage)
        {
            _beverage = beverage;
            PrepTime = _beverage.PrepTime + 300;
        }
        public decimal GetCost()
        {
            return _beverage.GetCost() + 0.75M;
        }

        public string GetDescription()
        {
            return _beverage.GetDescription() + " with extra syrup";
        }
    }
}

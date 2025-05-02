using CoffeeCrafter.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeCrafter.Beverages
{
    internal class Cappuccino : IBeverage
    {
        internal decimal Cost { get; private set; }
        internal string Description = "a cappuccino";
        public int PrepTime { get; init; }
        public Cappuccino(decimal c)
        {
            Cost = c;
            PrepTime = 12000;
        }
        public decimal GetCost()
        {
            return Cost;
        }

        public string GetDescription()
        {
            return Description;
        }
    }
}

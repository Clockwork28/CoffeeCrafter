using CoffeeCrafter.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeCrafter.Beverages
{
    internal class Latte : IBeverage
    {
        internal decimal Cost { get; private set; }
        internal string Description = "a latte";
        public int PrepTime { get; init; }
        public Latte(decimal c)
        {
            Cost = c;
            PrepTime = 15000;
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

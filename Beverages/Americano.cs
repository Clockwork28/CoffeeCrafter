using CoffeeCrafter.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeCrafter.Beverages
{
    internal class Americano : IBeverage
    {
        internal decimal Cost { get; private set; }
        public int PrepTime { get; init; }

        internal string Description = "an americano";

        public Americano(decimal c)
        {
            Cost = c;
            PrepTime = 1100;
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

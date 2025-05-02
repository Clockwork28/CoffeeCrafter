using CoffeeCrafter.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeCrafter.Beverages
{
    internal class Espresso : IBeverage
    {
        internal decimal Cost { get; private set; }
        internal string Description = "an espresso";
        public int PrepTime { get; init; }
        public Espresso(decimal c)
        {
            Cost = c;
            PrepTime = 5000;
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

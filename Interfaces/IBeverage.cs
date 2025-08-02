using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeCrafter.Interfaces
{
    public interface IBeverage
    {
        public int PrepTime { get; }
        decimal GetCost();
        string GetDescription();
    }
}

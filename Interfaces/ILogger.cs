using CoffeeCrafter.OrderSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeCrafter.Interfaces
{
    public interface ILogger 
    {
        Task LogOrder(int id, IBeverage beverage, decimal tip);
    }
}

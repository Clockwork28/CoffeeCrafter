using CoffeeCrafter.OrderSystem;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeCrafter.Interfaces
{
    public interface IServingStrategy
    {
        void Enqueue(OrderDTO order);
        OrderDTO? Dequeue();
    }
}

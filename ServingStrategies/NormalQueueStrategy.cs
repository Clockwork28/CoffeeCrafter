using CoffeeCrafter.Interfaces;
using CoffeeCrafter.OrderSystem;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeCrafter.ServingStrategies
{
    internal class NormalQueueStrategy : IServingStrategy
    {
        public ConcurrentQueue<OrderDTO> NormalQueue;
        public NormalQueueStrategy()
        {
            NormalQueue = new ConcurrentQueue<OrderDTO>();
        }
        public void Enqueue(OrderDTO order)
        {
            NormalQueue.Enqueue(order);
        }
        public OrderDTO? Dequeue()
        {
            if (NormalQueue.TryDequeue(out var order))
            {
                return order;
            }
            else
            {
                return null;
            }
        }
    }
}

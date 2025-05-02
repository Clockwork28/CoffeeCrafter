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
    internal class VipQueueStrategy : IServingStrategy
    {
        public ConcurrentQueue<OrderDTO> VipQueue;
        public VipQueueStrategy()
        {
            VipQueue = new ConcurrentQueue<OrderDTO>();
        }

        public void Enqueue(OrderDTO order)
        {
            VipQueue.Enqueue(order);
        }
        public OrderDTO? Dequeue()
        {
            if (VipQueue.TryDequeue(out var order))
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

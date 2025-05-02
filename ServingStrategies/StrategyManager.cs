using CoffeeCrafter.Interfaces;
using CoffeeCrafter.OrderSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeCrafter.ServingStrategies
{
    internal class StrategyManager
    {
        private int VipCounter = 0;
        public NormalQueueStrategy _normalQueue;
        public VipQueueStrategy _vipQueue;

        public StrategyManager(NormalQueueStrategy normalQ, VipQueueStrategy vipQ)
        {
            _normalQueue = normalQ;
            _vipQueue = vipQ;
        }

        public void EnqueueStrategy(OrderDTO order)
        {
            if (order.status.ToUpper() == "VIP")
                _vipQueue.Enqueue(order);
            else
                _normalQueue.Enqueue(order);

        }
        public OrderDTO? DequeueStrategy()
        {
            if (VipCounter < 3 && !_vipQueue.VipQueue.IsEmpty)
            {
                var order = _vipQueue.Dequeue();
                if (order != null)
                {
                    VipCounter++;
                    return order;
                }

                else
                {
                    VipCounter = 0;
                    return _normalQueue.Dequeue();
                }

            }
            else
            {
                var order = _normalQueue.Dequeue();
                if (order != null)
                {
                    VipCounter = 0;
                    return order;
                }

                else
                {
                    VipCounter++;
                    return _vipQueue.Dequeue();
                }


            }
        }

        public bool AreQueuesEmpty()
        {
            if (_vipQueue.VipQueue.IsEmpty && _normalQueue.NormalQueue.IsEmpty)
                return true;

            return false;
        }

    }
}

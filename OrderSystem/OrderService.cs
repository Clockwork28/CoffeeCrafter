using CoffeeCrafter.Clients;
using CoffeeCrafter.Decorators;
using CoffeeCrafter.Factory;
using CoffeeCrafter.Interfaces;
using CoffeeCrafter.Loggers;
using CoffeeCrafter.ServingStrategies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeCrafter.OrderSystem
{
    internal class OrderService
    {
        private StrategyManager _strategyManager;
        private ClientsManager _clientsManager;
        private CoffeeFactory _coffeeFactory;
        private ILogger _logger;
        public OrderService(StrategyManager manager, CoffeeFactory coffeeFactory, ClientsManager clientsManager, ILogger logger)
        {
            _strategyManager = manager;
            _clientsManager = clientsManager;
            _coffeeFactory = coffeeFactory;
            _logger = logger;
        }

        public async Task Run()
        {
            var tasks = new List<Task>();
            while(!_strategyManager.AreQueuesEmpty())
            {
                Console.ResetColor();

                var order = _strategyManager.DequeueStrategy();
                if (order != null)
                    tasks.Add(HandleOrder(order));
                await Task.Delay(2000);
            }
            await Task.WhenAll(tasks);
            
        }
 
        private void NotifyObserver(IObserver observer, int id)
        {
                observer.Update(id);
        }
        public void PlaceOrder(OrderDTO order)
        {
            _strategyManager.EnqueueStrategy(order);
        }
        public async Task HandleOrder(OrderDTO order)
        {
            var beverage = await _coffeeFactory.Make(order);
            await _logger.LogOrder(order.id, beverage);
            if (_clientsManager.Clients.ContainsKey(order.id))
            {
                NotifyObserver(_clientsManager.Clients.GetValueOrDefault(order.id)!, order.id);
                _clientsManager.RemoveClient(order.id);
            }
                
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                throw new Exception($"Cannot notify client with order ID {order.id}: \nNo such client in the list.");
            }
        }
    }
}

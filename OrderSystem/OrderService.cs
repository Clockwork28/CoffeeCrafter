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
                _clientsManager.RandomCancel();
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
            if (_clientsManager.Clients.ContainsKey(order.id))
            {
                try
                {

                    var beverage = await _coffeeFactory.Make(order, _clientsManager.Clients.GetValueOrDefault(order.id)!.Token);
                    await _logger.LogOrder(order.id, beverage);
                    NotifyObserver(_clientsManager.Clients.GetValueOrDefault(order.id)!, order.id);
                    _clientsManager.RemoveClient(order.id);
                }
                catch (OperationCanceledException)
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.Write($"[ID: {order.id}] ");
                    Console.ResetColor();
                    Console.Write("Order was cancelled by the client.\n");
                }
                
            }
                
            else
            {
                throw new Exception($"The client with order ID {order.id} does not exist in the list.");
            }
        }
    }
}

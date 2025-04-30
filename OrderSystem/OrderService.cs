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
        private StrategyManager _manager;
        private ClientsManager _clientsManager;
        private CoffeeFactory _coffeeFactory;
        private Logger _logger;
        public OrderService(StrategyManager manager, CoffeeFactory coffeeFactory, ClientsManager clientsManager, Logger logger)
        {
            _manager = manager;
            _clientsManager = clientsManager;
            _coffeeFactory = coffeeFactory;
            _logger = logger;
        }
 
        public void NotifyObserver(IObserver observer)
        {
                observer.Update();
        }
        public void PlaceOrder(OrderDTO order)
        {
            _manager.EnqueueStrategy(order);
        }
        public async Task HandleOrder(OrderDTO order)
        {
            await _logger.LogOrder(order.id, await _coffeeFactory.Make(order));
            if (_clientsManager.Clients.ContainsKey(order.id))
                NotifyObserver(_clientsManager.Clients.GetValueOrDefault(order.id)!);
            else
            {
                throw new Exception($"{Console.ForegroundColor = ConsoleColor.Red}Cannot notify client with order ID {order.id}: \nNo such client in the list.{Console.ResetColor}");
            }
        }
    }
}

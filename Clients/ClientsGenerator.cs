using CoffeeCrafter.OrderSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeCrafter.Clients
{
    internal class ClientsGenerator
    {
        private static int Counter;
        private static int MaxClients = 30;
        private string[] CoffeeTypes { get; init; }
        private string[] Extras { get; init; }
        private ClientsManager _clientsManager;
        private OrderService _orderService;

        public ClientsGenerator(ClientsManager clientsManager, OrderService orderService)
        {
            _clientsManager = clientsManager;
            _orderService = orderService;
            CoffeeTypes = ["espresso", "americano", "cappuccino", "latte"];
            Extras = ["", "milk", "syrup", "cream"];
        }
        private string StatusPicker()
        {
            Random rnd = new();
            int roll = rnd.Next(100);

            if (roll < 70)
                return "NORMAL";
            else
                return "VIP";
        }
        private OrderDTO GenerateOrder()
        {
            Random rnd = new();
            var type = CoffeeTypes[rnd.Next(CoffeeTypes.Length)];
            string[] extras = {Extras[rnd.Next(Extras.Length)], Extras[rnd.Next(Extras.Length)], Extras[rnd.Next(Extras.Length)]};
            int id = Interlocked.Increment(ref Counter);
            return new(id, type, StatusPicker(), extras);
        }
        private void GenerateClient()
        {
                Console.ResetColor();
                var order = GenerateOrder();
                _orderService.PlaceOrder(order);
                _clientsManager.AddClient(order.id, new Client());
        }

        public async Task Run()
        {
            while (Counter < MaxClients)
            {
                GenerateClient();
                await Task.Delay(1000);
            }
            
        }
    }
}

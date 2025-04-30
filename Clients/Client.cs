using CoffeeCrafter.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeCrafter.Clients
{
    internal class Client : IObserver
    {
        private readonly CancellationTokenSource _cts = new();
        public CancellationToken Token => _cts.Token;
        public void Update()
        {
            Console.WriteLine($"{Console.ForegroundColor = ConsoleColor.DarkGreen}Client: {Console.ResetColor}Thank you for my Coffee!");
        }

        public void CancelOrder()
        {
            _cts.Cancel();
        }
    }
}

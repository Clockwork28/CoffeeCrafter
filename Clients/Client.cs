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

        public void Update(int id)
        {
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.Write($"[ID: {id}] ");
            Console.ResetColor();
            Console.Write("Client: Thank you for my coffee!\n");
            
        }

        public void CancelOrder()
        {
            _cts.Cancel();
        }
    }
}

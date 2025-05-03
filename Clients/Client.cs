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
        public decimal Tip { get; set; }

        public void Update(int id, decimal cost)
        {
            RandomTip(cost);
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.Write($"[ID: {id}] ");
            Console.ResetColor();
            Console.Write($"Client: Here's {cost:F2}$");
            if (Tip > 0)
                Console.Write($" and a {Tip:F2}$ tip. ");
            else
                Console.Write(". ");
                
                Console.Write("Thanks!\n");
        }
        public void RandomTip(decimal cost)
        {
            Random rnd = new();
            int roll = rnd.Next(100);
            if (roll < 28)
            {
                decimal tipVal = (decimal)rnd.Next(5, 20) / 100;
                Tip = Math.Round(cost * tipVal, 2, MidpointRounding.AwayFromZero);
            }
            else
                Tip = 0;
        }
        public void CancelOrder()
        {
            _cts.Cancel();
        }

       
    }
}

using CoffeeCrafter.Interfaces;
using CoffeeCrafter.OrderSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace CoffeeCrafter.Loggers
{
    internal class Logger : ILogger, IDisposable
    {
        private StreamWriter _writer;
        public Logger()
        {
            _writer = new("Log.json", false);
        }
        public async Task LogOrder(int id, IBeverage beverage, decimal tip)
        {
            var entry = new LogEntry(
                id,
                beverage.GetDescription(),
                beverage.GetCost(),
                beverage.PrepTime,
                tip
            );
            var json = JsonSerializer.Serialize(entry, new JsonSerializerOptions
            {
                WriteIndented = false,
            });

            await _writer.WriteLineAsync(json);
        }
        public void Dispose()
        {
            _writer.Close();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"\nLOGGER: Log.json saved.");
            Console.ResetColor();
        }
    }
}

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
            _writer = new("Log.json", append: true);
        }
        public async Task LogOrder(int id, IBeverage beverage)
        {
            var entry = new LogEntry(
                id,
                beverage.GetDescription(),
                beverage.GetCost(),
                beverage.PrepTime
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
            Console.WriteLine($"{Console.ForegroundColor = ConsoleColor.DarkYellow}LOGGER: Log.txt saved.{Console.ResetColor}");
        }
    }
}

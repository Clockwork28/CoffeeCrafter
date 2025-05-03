using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace CoffeeCrafter.Loggers
{
    internal class Reporter : IDisposable
    {
        private StreamReader _reader;
        private List<LogEntry> _logEntries { get; set; }
        public Reporter()
        {
            _reader = new("Log.json");
            _logEntries = [];
        }
        private async Task ReadLog()
        {
            string? line;
            while ((line = await _reader.ReadLineAsync()) != null)
            {
                var entry = JsonSerializer.Deserialize<LogEntry>(line);
                if (entry != null)
                _logEntries.Add(entry);
            }
        }
        public async Task GenerateReport()
        {
            await ReadLog();
            var mostPopular = _logEntries.GroupBy(x => x.Description).OrderByDescending(x => x.Count()).First().Key;
            var averageTime = Math.Round(_logEntries.Select(x => x.PrepTime).Average() / 1000, 2, MidpointRounding.AwayFromZero);
            var totalSales = _logEntries.Select(x => x.Cost).Sum();
            var biggestOrder = _logEntries.OrderByDescending(x => x.Cost).First();
            var totalTips = _logEntries.Select(x => x.Tip).Sum();
            decimal onlyTipped = 0;
            double averageTipPercentage = 0;
            if (totalTips > 0)
            {
                onlyTipped = _logEntries.Where(x => x.Tip > 0).Select(x => x.Cost).Sum();
                averageTipPercentage = Math.Round((double)totalTips / (double)onlyTipped, 2, MidpointRounding.AwayFromZero) * 100;
            }

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\n---------- Daily Report -----------\n");
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.Write("Most popular drink: ");
            Console.ResetColor();
            Console.Write($"{mostPopular}.\n");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.Write("Average preparation time: ");
            Console.ResetColor();
            Console.Write($"{averageTime} seconds.\n");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.Write("Most expensive order: ");
            Console.ResetColor();
            Console.Write($"{biggestOrder.Description} ({biggestOrder.Cost}$).\n");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.Write("Total sales: ");
            Console.ResetColor();
            Console.Write($"{totalSales}$.\n");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.Write("Total tips: ");
            Console.ResetColor();
            Console.Write($"{totalTips}$");
            if (totalTips > 0)
                Console.Write($" (average tip percentage: {averageTipPercentage}%).\n");
            else
                Console.Write(".\n");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("\n-----------------------------------\n");
            Console.ResetColor();

        }

        public void Dispose()
        {
            _reader.Close();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeCrafter.Loggers
{
    internal record LogEntry(int Id, string Description, decimal Cost, int PrepTime);
}

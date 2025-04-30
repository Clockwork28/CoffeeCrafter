using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeCrafter.OrderSystem
{
    public record OrderDTO(int id, string type, string status, params string[] extras);
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeCrafter.Interfaces
{
    interface IObserver
    {
        void Update(int id, decimal cost);
    }
}

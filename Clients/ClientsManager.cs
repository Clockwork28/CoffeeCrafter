using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeCrafter.Clients
{
    internal class ClientsManager
    {
        public Dictionary<int, Client> Clients { get; set; }
        public ClientsManager()
        {
            Clients = new Dictionary<int, Client>();
        }
        public void AddClient(int id, Client client)
        {
            if (!Clients.ContainsKey(id))
                Clients.Add(id, client);
            else
               throw new ArgumentException($"Order ID already in the list!");
        }
        public void RemoveClient(int id)
        {
            Clients.Remove(id);
        }

        public void RandomCancel()
        {
            Random rnd = new();
            int roll = rnd.Next(100);
            if (roll > 84)
            {
                Clients.Last().Value.CancelOrder();
            }
        }
    }
}

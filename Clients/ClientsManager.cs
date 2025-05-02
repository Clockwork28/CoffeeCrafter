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
            //if (!Clients.ContainsKey(id))
                Clients.Add(id, client);
            //else
             //   Console.ForegroundColor = ConsoleColor.Red;
              //  throw new ArgumentException($"Order ID already in the list!");
        }
        public void RemoveClient(int id)
        {
            Clients.Remove(id);
        }
    }
}

using CoffeeCrafter.Clients;
using CoffeeCrafter.Factory;
using CoffeeCrafter.Interfaces;
using CoffeeCrafter.Loggers;
using CoffeeCrafter.OrderSystem;
using CoffeeCrafter.ServingStrategies;
using Microsoft.Extensions.DependencyInjection;

var services = new ServiceCollection();

services.AddSingleton<CoffeeFactory>();
services.AddSingleton<VipQueueStrategy>();
services.AddSingleton<NormalQueueStrategy>();
services.AddSingleton<StrategyManager>();
services.AddTransient<IObserver, Client>();
services.AddSingleton<ClientsManager>();
services.AddSingleton<Logger>();
services.AddSingleton<ILogger>(sp => sp.GetRequiredService<Logger>());
services.AddSingleton<OrderService>();
services.AddSingleton<ClientsGenerator>();


var serviceProvider = services.BuildServiceProvider();
using (var logger = serviceProvider.GetRequiredService<Logger>())
{
    var orderService = serviceProvider.GetRequiredService<OrderService>();
    var clientsGenerator = serviceProvider.GetRequiredService<ClientsGenerator>();
    var clientsRuntime = clientsGenerator.Run();
    var orderRuntime = orderService.Run();
    await Task.WhenAll(clientsRuntime, orderRuntime);
}

Console.WriteLine("Finish");
// TODO: Add a LINQ-based daily report generator that processes the log after runtime ends,
//       summarizing the orders according to predefined reporting requirements.
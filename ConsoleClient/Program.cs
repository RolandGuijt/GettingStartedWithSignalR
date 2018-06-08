using System;
using Microsoft.AspNetCore.SignalR.Client;
using Microsoft.Extensions.DependencyInjection;

namespace ConsoleClient
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Press a key to start listening..");
            Console.ReadKey();
            var connection = new HubConnectionBuilder()
                .WithUrl("http://localhost:60907/coffeehub")
                .AddMessagePackProtocol()
                .Build();

            connection.On<Order>("NewOrder", (order) => 
                Console.WriteLine($"Somebody ordered an {order.Product}"));

            connection.StartAsync().GetAwaiter().GetResult();

            Console.WriteLine("Listening. Press a key to quit");
            Console.ReadKey();
        }
    }
}

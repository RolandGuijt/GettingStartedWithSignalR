using System;
using System.Net.WebSockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using WiredBrain.Helpers;
using WiredBrain.Hubs;
using WiredBrain.Models;

namespace WiredBrain.Controllers
{
    [Route("[controller]")]
    public class CoffeeController : Controller
    {
        private readonly IHubContext<CoffeeHub> coffeeHub;

        public CoffeeController(OrderChecker orderChecker, IHttpContextAccessor httpContextAccessor, IHubContext<CoffeeHub> coffeeHub)
        {
            this.coffeeHub = coffeeHub;
        }

        [HttpPost]
        public async Task<IActionResult> OrderCoffee([FromBody]Order order)
        {
            await coffeeHub.Clients.All.SendAsync("NewOrder", order);
            //Start process for order
            return Accepted(1); //return order id 1
        }
    }
}

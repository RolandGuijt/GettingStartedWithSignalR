using System;
using Microsoft.AspNetCore.Mvc;
using WiredBrain.Helpers;
using WiredBrain.Models;

namespace WiredBrain.Controllers
{
    [Route("[controller]")]
    public class CoffeeController: Controller
    {
        private readonly OrderChecker _orderChecker;

        public CoffeeController(OrderChecker orderChecker)
        {
            _orderChecker = orderChecker;
        }

        [HttpPost]
        public IActionResult OrderCoffee(Order order)
        {
            //Start process for order
            return Accepted(1); //return order id 1
        }

        [HttpGet("{orderNo}")]
        public IActionResult GetUpdateForOrder(int orderNo)
        {
            var result = _orderChecker.GetUpdate(orderNo);
            if (result.New)
                return new ObjectResult(result);
            return NoContent();
        }
    }
}

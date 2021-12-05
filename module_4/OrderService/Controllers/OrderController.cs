using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace OrderService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly ILogger<OrderController> _logger;

        public OrderController(ILogger<OrderController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<Order> Get()
        {
            return new List<Order> {
                new Order { Id = 1, CustomerId = 1, Date = DateTime.Now, Price = 100.50M },
                new Order { Id = 2, CustomerId = 1, Date = DateTime.Now, Price = 200.50M },
                new Order { Id = 3, CustomerId = 2, Date = DateTime.Now, Price = 300.50M },
                new Order { Id = 4, CustomerId = 2, Date = DateTime.Now, Price = 400.50M },
            };
        }
    }
}

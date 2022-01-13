using System.Collections.Generic;
using System.Threading.Tasks;
using CustomerService.Models;
using CustomerService.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CustomerService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CustomersController : ControllerBase
    {
        private readonly ILogger<CustomersController> _logger;
        private readonly ICustomerRepository _repository;

        public CustomersController(ILogger<CustomersController> logger, ICustomerRepository repository) 
        {
            _logger = logger;
            _repository = repository;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Customer>> Get(int id)
        {
            var customer = await _repository.Get(id);
            if(customer == null){
                return NotFound();
            }
            return Ok(customer);
        }

        [HttpPost]
        public async Task<ActionResult> Create(Customer customer)
        {
            await _repository.Add(customer);
            return Ok();
        }
    }
}

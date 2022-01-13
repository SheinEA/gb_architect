using System.Collections.Generic;
using System.Threading.Tasks;
using HistoryService.Models;
using HistoryService.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace HistoryService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HistoryController : ControllerBase
    {
        private readonly ILogger<HistoryController> _logger;
        private readonly IHistoryRepository _repository;

        public HistoryController(ILogger<HistoryController> logger, IHistoryRepository repository) 
        {
            _logger = logger;
            _repository = repository;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<History>> Get(int id)
        {
            var history = await _repository.Get(id);
            if(history == null){
                return NotFound();
            }
            return Ok(history);
        }

        [HttpPost]
        public async Task<ActionResult> Create(History history)
        {
            await _repository.Add(history);
            return Ok();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using POC.Service.Interfaces.Services;
//using POC.Service.Models;

namespace POC.Service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KafkaProducerController : ControllerBase
    {
        private readonly IKafkaProducerService _kafkaProducerService;
        public KafkaProducerController(IKafkaProducerService kafkaProducerService)
        {
            _kafkaProducerService = kafkaProducerService;
        }

        [HttpGet("")]
        public async Task<ActionResult<IEnumerable<TModel>>> GetTModels()
        {
            // TODO: Your code here
            if(await _kafkaProducerService.SenderMessageKafka("Hello World!"))
            return Ok("200");

            return BadRequest("400");

        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TModel>> GetTModelById(int id)
        {
            // TODO: Your code here
            await Task.Yield();

            return null;
        }

        [HttpPost("")]
        public async Task<ActionResult<TModel>> PostTModel(TModel model)
        {
            // TODO: Your code here
            await Task.Yield();

            return null;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutTModel(int id, TModel model)
        {
            // TODO: Your code here
            await Task.Yield();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<TModel>> DeleteTModelById(int id)
        {
            // TODO: Your code here
            await Task.Yield();

            return null;
        }
    }

    public class TModel{

    }
}
using MacroTracker.Users.Application;
using MacroTracker.Users.Application.Exceptions;
using MacroTracker.Users.Application.UseCases.RegisterTrainer;
using MacroTracker.Users.Application.UseCases.Trainers.DeactivateTrainer;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MacroTracker.Users.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrainersController : BaseApiController
    {
        private readonly ILogger<TrainersController> _logger;
        public TrainersController(IMediator mediator, ILogger<TrainersController> logger) : base(mediator) => _logger = logger;

        // GET: api/Trainers
        [HttpGet]
        public IEnumerable<string> Get() => new string[] { "value1", "value2" };

        // GET: api/Trainers/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Trainers
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] RegisterTrainerRequest request)
        {
            try
            {
                await Mediator.Send(request);
                return Ok();
            }
            catch (EntityAlreadyExistsException e)
            {
                _logger.LogError(e.Message);
                Response.StatusCode = 400;
                return BadRequest(e.Message);
            }
        }

        // PUT: api/Trainers/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            try
            {
                await Mediator.Send(new DeactivateTrainerRequest {
                    TrainerId = id
                });
                return NoContent();
            }
            catch (EntityInactiveException e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
using MacroTracker.Users.Application;
using MacroTracker.Users.Application.Exceptions;
using MacroTracker.Users.Application.UseCases.RegisterTrainer;
using MacroTracker.Users.Application.UseCases.Trainers.DeactivateTrainer;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MacroTracker.Users.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrainersController : BaseApiController
    {
        public TrainersController(IMediator mediator) : base(mediator)
        {
        }

        // GET: api/Trainers
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Trainers/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Trainers
        [HttpPost]
        public async void Post([FromBody] RegisterTrainerRequest request)
        {
            try
            {
                await Mediator.Send(request);
            }
            catch (EntityAlreadyExists e)
            {
                Response.StatusCode = 400;
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
            catch (UserAlreadyInactiveException e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
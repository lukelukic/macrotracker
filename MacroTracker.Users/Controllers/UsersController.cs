using MacroTracker.Users.Api.Controllers;
using MacroTracker.Users.Application.Exceptions;
using MacroTracker.Users.Application.UseCases;
using MacroTracker.Users.Application.UseCases.SearchUsers;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace MacroTracker.Users.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : BaseApiController
    {
        public UsersController(IMediator mediator) : base(mediator)
        {
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] RegisterUserUseCase model)
        {
            try
            {
                await Mediator.Send(model);
                return Ok();
            }
            catch (EntityAlreadyExistsException e)
            {
                return UnprocessableEntity(e.Message);
            }
        }

        [HttpGet]
        public IActionResult Get([FromQuery] SearchUsersQuery request)
        {
            try
            {
                return Ok(Mediator.Send(request).Result);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
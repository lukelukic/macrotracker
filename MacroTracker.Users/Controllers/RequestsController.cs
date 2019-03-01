using MacroTracker.Users.Application.Exceptions;
using MacroTracker.Users.Application.UseCases.Users.SendTrainingRequest;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace MacroTracker.Users.Api.Controllers
{
    [ApiController]
    public class RequestsController : BaseApiController
    {
        public RequestsController(IMediator mediator) : base(mediator)
        {
        }

        // POST: api/Requests
        [HttpPost("api/v1/requests")]
        public async Task<IActionResult> PostAsync([FromBody] SendTrainingRequestRequest request)
        {
            try
            {
                await Mediator.Send(request);
                return Ok();
            }
            catch (EntityNotFoundException e)
            {
                return NotFound(e.Message);
            }
            catch (EntityAlreadyExistsException e)
            {
                return Conflict(e.Message);
            }
            finally
            {
                BadRequest();
            }
        }

        [HttpPost("api/v1/requests/{requestId}/accept")]
        public void Accept(Guid requestId)
        {
            throw new NotSupportedException();
        }

        [HttpPost("api/v1/requests/{requestId}/decline")]
        public void Decline(Guid requestId)
        {
            throw new NotSupportedException();
        }
    }
}
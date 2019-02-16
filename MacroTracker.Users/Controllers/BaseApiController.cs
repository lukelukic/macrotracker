using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace MacroTracker.Users.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseApiController : ControllerBase
    {
        protected IMediator Mediator { get; }

        public BaseApiController(IMediator mediator) => Mediator = mediator;
    }
}
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace LocalTrip.Core.Api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    [System.Web.Http.Authorize]
    public class UserLoginController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<UserLoginController> _logger;

        public UserLoginController(ILogger<UserLoginController> logger,IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

    }
}
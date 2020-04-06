using System.Threading.Tasks;
using LocalTrip.Core.Api.Mappers;
using LocalTrip.Core.Api.ViewModels;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace LocalTrip.Core.Api.Controllers
{

    [Route("api/v1/[controller]")]
    [ApiController]
    [System.Web.Http.Authorize]
    public class UserAccountController : ControllerBase
    {
        
        private readonly IMediator _mediator;
        private readonly ILogger<UserAccountController> _logger;
        
        public UserAccountController(ILogger<UserAccountController> logger,IMediator mediator)
        {
            _mediator = mediator;
            _logger = logger;
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register([FromBody]AccountRegisterViewModel model)
        {
            var response = _mediator.Send(model.MapToCommand());
            return Ok(response);
        }
        
        [HttpGet("Detail")]
        public async Task<IActionResult> Detail([FromQuery]AccountDetailViewModel model)
        {
            var response = _mediator.Send(model.MapToCommand());
            return Ok(response);
        }
        
    }
}
using System.Threading.Tasks;
using System.Web.Http;
using LocalTrip.Core.Api.Mappers;
using LocalTrip.Core.Api.ViewModels;
using MediatR;
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

        [Microsoft.AspNetCore.Mvc.HttpPost("Register")]
        [Microsoft.AspNetCore.Authorization.Authorize("Bearer")]
        public async Task<IActionResult> Register([Microsoft.AspNetCore.Mvc.FromBody]AccountRegisterViewModel model)
        {
            var response = _mediator.Send(model.MapToCommand());
            return Ok(response);
        }
        
        [Microsoft.AspNetCore.Mvc.HttpGet("Detail")]
        [Microsoft.AspNetCore.Authorization.Authorize("Bearer")]
        public async Task<IActionResult> Detail([FromQuery]AccountDetailViewModel model)
        {
            var response = _mediator.Send(model.MapToCommand());
            return Ok(response);
        }

        [Microsoft.AspNetCore.Mvc.HttpPut("{document}")]
        [Microsoft.AspNetCore.Authorization.Authorize("Bearer")]
        public async Task<IActionResult> Update(string document
            ,[Microsoft.AspNetCore.Mvc.FromBody]AccountUpdateViewModel model)
        {
            var response = _mediator.Send(model.MapToCommand(document));
            return Ok(response);
        }

        [Microsoft.AspNetCore.Mvc.HttpPost("Login")]
        [Microsoft.AspNetCore.Authorization.Authorize("Bearer")]
        public async Task<IActionResult> Login([Microsoft.AspNetCore.Mvc.FromBody]AccountLoginViewModel model)
        {
            var response = _mediator.Send(model.MapToCommand());
            return Ok(response);
        }
    }
}
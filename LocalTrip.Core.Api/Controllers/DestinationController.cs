using System.Threading.Tasks;
using LocalTrip.Core.Api.Mappers;
using LocalTrip.Core.Api.ViewModels;
using LocalTrip.Travel.Project.Application.Core;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace LocalTrip.Core.Api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    [System.Web.Http.Authorize]
    public class DestinationController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<DestinationController> _logger;

        public DestinationController(ILogger<DestinationController> logger,IMediator mediator)
        {
            _mediator = mediator;
            _logger = logger;
        }
        
        [Microsoft.AspNetCore.Mvc.HttpGet]
        [Authorize("Bearer")]
        public async Task<IActionResult> Get([FromQuery]GetTripViewModel model)
        {
            _logger.LogInformation("GET / TRIPS"+System.Text.Json.JsonSerializer.Serialize(model));
            var response = await _mediator.Send(model.MapToCommand());
            return Ok(response);
            
        }
        
    }
}
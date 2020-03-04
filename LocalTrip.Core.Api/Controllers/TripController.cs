using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using LocalTrip.Core.Api.Mappers;
using LocalTrip.Core.Api.ViewModels;
using LocalTrip.Travel.Project.Application.Core;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace LocalTrip.Core.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TripController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<TripController> _logger;
        
        public TripController(ILogger<TripController> logger,
            IMediator mediator)
        {
            _mediator = mediator;
           _logger = logger;
        }

        
        [HttpPost]
        [Route("GetTrips")]
        public async Task<IActionResult> GetTrips([FromBody]GetTripViewModel model)
        {
            _logger.LogInformation("GET / TRIPS"+System.Text.Json.JsonSerializer.Serialize(model));
            var response = await _mediator.Send(model.MapToCommand());
            return Ok(response);
            
        }
        
    }
}
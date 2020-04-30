using System;
using System.Threading.Tasks;
using LocalTrip.Core.Api.Mappers;
using LocalTrip.Core.Api.ViewModels;
using LocalTrip.Travel.Project.Application.Commands.Request;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace LocalTrip.Core.Api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {

        private readonly IMediator _mediator;
        private readonly ILogger _logger;

        public CartController(ILogger<CartController> logger, IMediator mediator)
        {
            _mediator = mediator;
            _logger = logger;
        }

        [HttpPost]
        public async Task<IActionResult> AddCartItem([FromBody]AddCartItemViewModel model)
        {
            return Ok(await _mediator.Send(model.MapToCommand()));
        }

        [HttpGet]
        public async Task<IActionResult> GetById([FromQuery] int id)
        {
            return Ok(_mediator.Send(new GetCartItemByCartIdCommandRequest(id)));
        }

    }
}
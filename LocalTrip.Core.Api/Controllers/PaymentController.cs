using System.Collections.Generic;
using System.Threading.Tasks;
using LocalTrip.Travel.Project.Application.Commands.Request;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace LocalTrip.Core.Api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    [System.Web.Http.Authorize]
    public class PaymentController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger _logger;

        public PaymentController(ILogger<PaymentController> logger,IMediator mediator)
        {
            _mediator = mediator;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(_mediator.Send(new GetAllPaymentCommandRequest()));
        }
        
    }
}
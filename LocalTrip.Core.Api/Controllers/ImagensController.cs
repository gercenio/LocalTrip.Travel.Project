using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace LocalTrip.Core.Api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    [Authorize]
    public class ImagensController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<ImagensController> _logger;
        
        public ImagensController(ILogger<ImagensController> logger
            ,IMediator mediator)
        {
            _mediator = mediator;
            _logger = logger;
        }

        [HttpGet]
        public FileStreamResult Get(int id)
        {
            //Imagem imagem = _context.Imagens.FirstOrDefault(m => m.Id == id);
            //MemoryStream ms = new MemoryStream(imagem.Dados);
            //return new FileStreamResult(ms, imagem.ContentType);
            return null;
        }
        
        /*
        // GET
        public IActionResult Index()
        {
            return View();
        }*/
    }
}
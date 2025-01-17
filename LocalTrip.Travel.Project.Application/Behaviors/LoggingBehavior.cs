using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.Extensions.Logging;

namespace LocalTrip.Travel.Project.Application.Behaviors
{
    
    public class LoggingBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    {
        private readonly ILogger<LoggingBehavior<TRequest, TResponse>> _logger;

        public LoggingBehavior(ILogger<LoggingBehavior<TRequest, TResponse>> logger)
        {
            _logger = logger;
        }

        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next) 
        {
            _logger.Log(LogLevel.Debug,$"Handling {typeof(TRequest).Name}");
        
            var response = await next();
        
            _logger.Log(LogLevel.Debug,$"Handled {typeof(TResponse).Name}");
        
            return response;
        }
    }
}
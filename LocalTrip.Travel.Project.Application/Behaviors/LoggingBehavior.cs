using System.Threading;
using System.Threading.Tasks;
using MediatR;

namespace LocalTrip.Travel.Project.Application.Behaviors
{
    
    public class LoggingBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> 
    {
        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next) 
        {
            //await Logger.InfoAsync($"Handling {typeof(TRequest).Name}");
        
            var response = await next();
        
            //await Logger.InfoAsync($"Handled {typeof(TResponse).Name}");
        
            return response;
        }
    }
}
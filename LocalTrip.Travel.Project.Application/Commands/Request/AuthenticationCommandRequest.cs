using LocalTrip.Travel.Project.Application.Commands.Response;
using MediatR;

namespace LocalTrip.Travel.Project.Application.Commands.Request
{
    public class AuthenticationCommandRequest :IRequest<AuthenticationCommandResponse>
    {
        public string UserCode { get; set; }
        public string AccessKey { get; set; }
    }
}
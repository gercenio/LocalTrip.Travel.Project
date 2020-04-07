using LocalTrip.Travel.Project.Application.Commands.Response;
using MediatR;

namespace LocalTrip.Travel.Project.Application.Commands.Request
{
    public class AccountLoginCommandRequest : IRequest<AccountLoginCommandResponse>
    {
        public string Email { get; }
        public string Password { get; }

        public AccountLoginCommandRequest(string email, string password)
        {
            Email = email;
            Password = password;
        }
    }
}
using LocalTrip.Travel.Project.Application.Commands.Response;
using MediatR;

namespace LocalTrip.Travel.Project.Application.Commands.Request
{
    public class AccountDetailCommandRequest : IRequest<AccountDetailCommandResponse>
    {
        public string Document { get; }

        public AccountDetailCommandRequest(string document)
        {
            Document = document;
        }

    }
}
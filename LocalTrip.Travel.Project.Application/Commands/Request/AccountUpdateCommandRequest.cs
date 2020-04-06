using LocalTrip.Travel.Project.Application.Commands.Response;
using LocalTrip.Travel.Project.Domain.Enuns;
using MediatR;

namespace LocalTrip.Travel.Project.Application.Commands.Request
{
    public class AccountUpdateCommandRequest : IRequest<AccountUpdateCommandResponse>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Document { get; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public PeopleType Type { get; set; }

        public AccountUpdateCommandRequest(string document)
        {
            Document = document;
        }
    }
}
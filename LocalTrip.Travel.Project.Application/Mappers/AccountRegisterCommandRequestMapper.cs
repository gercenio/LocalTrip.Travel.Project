using LocalTrip.Travel.Project.Application.Commands.Request;
using LocalTrip.Travel.Project.Domain.Entities;
using LocalTrip.Travel.Project.Domain.Enuns;

namespace LocalTrip.Travel.Project.Application.Mappers
{
    public static class AccountRegisterCommandRequestMapper
    {
        public static People MapToDomain(this AccountRegisterCommandRequest request)
        {
            var result = new People(request.Document, request.FirstName, request.LastName);
            result.AddAccount(new PeopleAccount(AccountType.Customer,request.Password));
            result.AddContact(new PeopleContact(ContactType.Email,request.Email));
            result.AddContact(new PeopleContact(ContactType.Phone,request.Phone));
            result.AddPeopleType(request.Type);
            
            return result;
        }
    }
}
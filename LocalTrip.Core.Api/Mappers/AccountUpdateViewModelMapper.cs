using LocalTrip.Core.Api.ViewModels;
using LocalTrip.Travel.Project.Application.Commands.Request;
using LocalTrip.Travel.Project.Domain.Enuns;

namespace LocalTrip.Core.Api.Mappers
{
    public static class AccountUpdateViewModelMapper
    {
        public static AccountUpdateCommandRequest MapToCommand(this AccountUpdateViewModel vm, string document)
        => new AccountUpdateCommandRequest(document)
        {
            FirstName = vm.FirstName,
            LastName = vm.LastName,
            Email = vm.Email,
            Phone = vm.Phone,
            Type = (PeopleType)vm.Type
        };
    }
}
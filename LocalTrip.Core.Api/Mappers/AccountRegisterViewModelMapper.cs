using LocalTrip.Core.Api.ViewModels;
using LocalTrip.Travel.Project.Application.Commands.Request;
using LocalTrip.Travel.Project.Domain.Enuns;

namespace LocalTrip.Core.Api.Mappers
{
    public static class AccountRegisterViewModelMapper
    {
        public static AccountRegisterCommandRequest MapToCommand(this AccountRegisterViewModel vm)
        => new AccountRegisterCommandRequest()
        {
            FirstName = vm.FirstName,
            LastName = vm.LastName,
            Document = vm.Document,
            Password = vm.Password,
            Phone = vm.Phone,
            Email = vm.Email,
            Type = (PeopleType)vm.Type
            
        };
    }
}
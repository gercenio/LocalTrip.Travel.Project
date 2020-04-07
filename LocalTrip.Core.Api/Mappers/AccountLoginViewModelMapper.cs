using LocalTrip.Core.Api.ViewModels;
using LocalTrip.Travel.Project.Application.Commands.Request;

namespace LocalTrip.Core.Api.Mappers
{
    public static class AccountLoginViewModelMapper
    {
        public static AccountLoginCommandRequest MapToCommand(this AccountLoginViewModel vm)
        => new AccountLoginCommandRequest(vm.Email,vm.Password);
    }
}
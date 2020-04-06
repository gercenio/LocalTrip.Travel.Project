using LocalTrip.Core.Api.ViewModels;
using LocalTrip.Travel.Project.Application.Commands.Request;

namespace LocalTrip.Core.Api.Mappers
{
    public static class AccountDetailViewModelMapper
    {
        public static AccountDetailCommandRequest MapToCommand(this AccountDetailViewModel vm)
        => new AccountDetailCommandRequest(vm.Document);
    }
}
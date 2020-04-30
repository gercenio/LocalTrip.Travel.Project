using LocalTrip.Core.Api.ViewModels;
using LocalTrip.Travel.Project.Application.Commands.Request;

namespace LocalTrip.Core.Api.Mappers
{
    public static class UpdateCartItemViewModelMapper
    {
        public static UpdateCartItemCommandRequest MapToCommand(this UpdateCartItemViewModel vm)
        => new UpdateCartItemCommandRequest(vm.CartItemId,vm.Count);
        
    }
}
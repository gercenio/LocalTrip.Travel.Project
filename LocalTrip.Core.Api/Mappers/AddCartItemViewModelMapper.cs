using LocalTrip.Core.Api.ViewModels;
using LocalTrip.Travel.Project.Application.Commands.Request;

namespace LocalTrip.Core.Api.Mappers
{
    public static class AddCartItemViewModelMapper
    {
        public static AddItemToCartCommandRequest MapToCommand(this AddCartItemViewModel vm)
        => new AddItemToCartCommandRequest(vm.CartId,vm.DestinationId,vm.PeopleId,vm.Count);
    }
}
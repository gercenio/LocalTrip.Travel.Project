using LocalTrip.Core.Api.ViewModels;
using LocalTrip.Travel.Project.Application.Commands.Request;

namespace LocalTrip.Core.Api.Mappers
{
    public static class GetTripViewModelMapper
    {
        public static FindTripCommandRequest MapToCommand(this GetTripViewModel model)
        => new FindTripCommandRequest(model.Price,model.City,model.Country);
    }
}
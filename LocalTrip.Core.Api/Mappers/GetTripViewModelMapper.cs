using LocalTrip.Core.Api.ViewModels;
using LocalTrip.Travel.Project.Application.Commands.Request;

namespace LocalTrip.Core.Api.Mappers
{
    public static class GetTripViewModelMapper
    {
        public static FindTripCommandRequest MapToCommand(this GetTripViewModel model)
        {
            return new FindTripCommandRequest()
            {
                CityDestination = model.CityDestination,
                CountryDestination =  model.CityDestination,
                CityOrigem = model.CityOrigem,
                CountryOrigem = model.CountryOrigem,
                DateTrip = model.DateTrip
                
            };
        }
    }
}
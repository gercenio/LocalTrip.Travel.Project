using LocalTrip.Travel.Project.Domain.Entities;
using LocalTrip.Travel.Project.Infra.Data.Dtos;

namespace LocalTrip.Travel.Project.Infra.Data.Mappers
{
    public static class TripDtoMapper
    {
        public static TripDto MapToDto(this Trip domain)
        {
            return new TripDto()
            {
                CityOrigem = domain.Origem.Description,
                CityDestination =  domain.Destination.Description,
                
            };
        }
    }
}
using LocalTrip.Travel.Project.Domain.Entities;
using LocalTrip.Travel.Project.Infra.Data.Dtos;

namespace LocalTrip.Travel.Project.Infra.Data.Mappers
{
    public static class DestinationDtoMapper
    {
        public static Destination MapToDomain(this DestinationDto dto)
        {
            var entity = new Destination(dto.Name, dto.Price, dto.Url, dto.Country, dto.City,dto.TokenImage);
            return entity;
        }

        public static DestinationDto MapToDto(this Destination entity)
        => new DestinationDto()
        {
            Name =  entity.Name,
            Rating = entity.Rating,
            City = entity.City,
            Country = entity.Country,
            TokenImage = entity.TokenImage,
            Url = entity.Url,
            Price = entity.Price
        };
        
    }
}
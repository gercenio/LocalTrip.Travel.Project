using LocalTrip.Travel.Project.Domain.Entities;
using LocalTrip.Travel.Project.Infra.Data.Dtos;

namespace LocalTrip.Travel.Project.Infra.Data.Mappers
{
    public static class CartDtoMapper
    {
        public static CartDto MapToDto(this Cart entity)
        => new CartDto()
        {
            Id = entity.Id,
            CreatedDate = entity.CreatedDate
        };
        
    }
}
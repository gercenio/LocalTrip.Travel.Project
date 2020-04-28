using LocalTrip.Travel.Project.Domain.Entities;
using LocalTrip.Travel.Project.Infra.Data.Dtos;

namespace LocalTrip.Travel.Project.Infra.Data.Mappers
{
    public static class CartItemMapper
    {
        public static CartItemDto MapToDto(this CartItem entity)
        => new CartItemDto()
        {
            Id = entity.Id,
            CartId = entity.CartId,
            DestinationId = entity.DestinationId,
            PeopleId = entity.PeopleId,
            Count = entity.Count
        };
    }
}
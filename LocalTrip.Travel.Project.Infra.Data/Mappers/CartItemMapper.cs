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
            Count = entity.Count
        };
        
        public static CartItem MapToDomain(this CartItemDto dto)
        => new CartItem(dto.DestinationId,dto.CartId,dto.Count);
    }
}
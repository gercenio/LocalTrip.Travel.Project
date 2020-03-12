using LocalTrip.Travel.Project.Domain.Entities;
using LocalTrip.Travel.Project.Infra.Data.Dtos;

namespace LocalTrip.Travel.Project.Infra.Data.Mappers
{
    public static class GiftCardDtoMapper
    {
        public static GiftCard MapToDomain(this GiftCardDto dto)
        {
            return new GiftCard(dto.Name,dto.ImageValue);
        }
    }
}
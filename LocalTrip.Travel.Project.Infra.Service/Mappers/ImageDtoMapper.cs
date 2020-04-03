using LocalTrip.Travel.Project.Domain.Entities;
using LocalTrip.Travel.Project.Infra.Service.Dtos.ServiceImage;

namespace LocalTrip.Travel.Project.Infra.Service.Mappers
{
    public static class ImageDtoMapper
    {
        public static DestinationImage MapToDomain(this ImageDto dto)
        => new DestinationImage(dto.Name,dto.Path);
    }
}
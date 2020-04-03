using System.Collections.Generic;
using LocalTrip.Travel.Project.Domain.Entities;
using LocalTrip.Travel.Project.Infra.Service.Dtos.ServiceImage;

namespace LocalTrip.Travel.Project.Infra.Service.Mappers
{
    public static class BaseImageResponseDtoMapper
    {
        public static Destination MapToDomain(this BaseImageResponseDto dto)
        {
          var result = new Destination(string.Empty,0,string.Empty,string.Empty,string.Empty,string.Empty);

          foreach (var img in dto.Data)
          {
           result.AddImage(img.MapToDomain());   
          }
          return result;
        }
        
    }
}
using System.Collections.Generic;

namespace LocalTrip.Travel.Project.Infra.Service.Dtos.ServiceImage
{
    public class BaseImageResponseDto
    {
        public bool isSuccess { get; set; }
        public string messages { get; set; }
        public List<ImageDto> Data { get; set; }
    }
}
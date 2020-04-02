using System.Collections.Generic;
using System.Threading.Tasks;
using LocalTrip.Travel.Project.Infra.Service.Dtos;
using LocalTrip.Travel.Project.Infra.Service.Dtos.ServiceImage;

namespace LocalTrip.Travel.Project.Infra.Service.Interfaces
{
    public interface IServiceImage
    {
        Task<BaseImageResponseDto> GetAll(string imagetoken);
    }
}
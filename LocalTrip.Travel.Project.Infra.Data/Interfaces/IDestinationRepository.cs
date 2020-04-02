using LocalTrip.Travel.Project.Infra.Data.Dtos;

namespace LocalTrip.Travel.Project.Infra.Data.Interfaces
{
    public interface IDestinationRepository : IRepository<DestinationDto>
    {
        string GetImageById(int Id);
    }
}
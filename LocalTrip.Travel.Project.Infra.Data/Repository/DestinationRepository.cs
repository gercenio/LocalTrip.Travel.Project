using LocalTrip.Travel.Project.Infra.Data.Dtos;
using LocalTrip.Travel.Project.Infra.Data.Interfaces;

namespace LocalTrip.Travel.Project.Infra.Data.Repository
{
    public class DestinationRepository : Repository<DestinationDto> , IDestinationRepository
    {
        public string GetImageById(int Id)
        {
            throw new System.NotImplementedException();
        }
    }
}
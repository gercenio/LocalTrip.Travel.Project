using LocalTrip.Travel.Project.Infra.Data.Dtos;
using LocalTrip.Travel.Project.Infra.Data.Interfaces;

namespace LocalTrip.Travel.Project.Infra.Data.Repository
{
    public class TripRepository : Repository<TripDto> , ITripRepository
    {
        
    }
}
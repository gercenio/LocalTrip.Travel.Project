using LocalTrip.Travel.Project.Domain.Entities;
using LocalTrip.Travel.Project.Domain.Enuns;
using LocalTrip.Travel.Project.Infra.Data.Dtos;

namespace LocalTrip.Travel.Project.Infra.Data.Mappers
{
    public static class PeopleAccountDtoMapper
    {
        public static PeopleAccount MapToDomain(this PeopleAccountDto dto)
        => new PeopleAccount((AccountType)dto.AccountType,dto.Password);
        
    }
}
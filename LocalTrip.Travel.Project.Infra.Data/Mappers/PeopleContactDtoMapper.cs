using LocalTrip.Travel.Project.Domain.Entities;
using LocalTrip.Travel.Project.Domain.Enuns;
using LocalTrip.Travel.Project.Infra.Data.Dtos;

namespace LocalTrip.Travel.Project.Infra.Data.Mappers
{
    public static class PeopleContactDtoMapper
    {
        public static PeopleContactDto MapToDto(this PeopleContact entity)
        => new PeopleContactDto()
        {
            Value = entity.Value,
            ContactType = (int)entity.Type
        };
        
        public static PeopleContact MapToDomain(this PeopleContactDto dto)
        => new PeopleContact((ContactType)dto.ContactType,dto.Value);
        
    }
}
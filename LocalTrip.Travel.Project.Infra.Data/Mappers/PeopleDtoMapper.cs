using System.Collections.Generic;
using System.Linq;
using LocalTrip.Travel.Project.Domain.Entities;
using LocalTrip.Travel.Project.Domain.Enuns;
using LocalTrip.Travel.Project.Infra.Data.Dtos;

namespace LocalTrip.Travel.Project.Infra.Data.Mappers
{
    public static class PeopleDtoMapper
    {
        public static PeopleDto MapToDto(this People entity)
        { 
            
            var result = new PeopleDto()
            {
              Document = entity.Document,
              FirstName = entity.FirstName,
              LastName = entity.LastName,
              PeopleType = (int) entity.Type,
              Account = new PeopleAccountDto()
              {
                  AccountType = (int) entity.Account.Type,
                  Password = entity.Account.Password
              }
            };
            
            foreach (var contact in entity.Contacts)
            {
                result.Contacts.Add(contact.MapToDto());
            }
            
            return result;
        }

        public static People MapToDomain(this PeopleDto dto)
        {
            if(dto == null)
                return new People(string.Empty,string.Empty,string.Empty);
            
            var result = new People(dto.Document,dto.FirstName,dto.LastName);
            result.AddPeopleType((PeopleType)dto.PeopleType);
            
            return result;
        }
    }
}
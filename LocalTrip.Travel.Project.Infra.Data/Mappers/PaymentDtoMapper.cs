using LocalTrip.Travel.Project.Domain.Entities;
using LocalTrip.Travel.Project.Infra.Data.Dtos;

namespace LocalTrip.Travel.Project.Infra.Data.Mappers
{
    public static class PaymentDtoMapper
    {
        public static Payment MapToDomain(this PaymentDto dto)
        {
            var result = new Payment(dto.Name);
            result.AddIdentity(dto.Id);
            return result;
        }
    }
}
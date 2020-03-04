using LocalTrip.Travel.Project.Domain.Entities;
using LocalTrip.Travel.Project.Infra.Data.Dtos;

namespace LocalTrip.Travel.Project.Infra.Data.Mappers
{
    public static class ApiAccountDtoMapper
    {
        public static ApiAccountDto MapToDto(this ApiAccount entity)
        {
            return  new ApiAccountDto()
            {
                UserCode = entity.UserCode,
                AccessKey = entity.AccessKey
            };
        }

        public static ApiAccount MapToDomain(this ApiAccountDto dto)
        {
            return new ApiAccount(dto.UserCode,dto.AccessKey);
        }
    }
}
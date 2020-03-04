using LocalTrip.Core.Api.ViewModels;
using LocalTrip.Travel.Project.Application.Commands.Request;

namespace LocalTrip.Core.Api.Mappers
{
    public static class AccountApiViewModelMapper
    {
        public static AuthenticationCommandRequest MapToCommand(this AccountApiViewModel model)
        {
            return new AuthenticationCommandRequest()
            {
                UserCode = model.UserCode,
                AccessKey = model.AccessKey
            };
        }
    }

   
}
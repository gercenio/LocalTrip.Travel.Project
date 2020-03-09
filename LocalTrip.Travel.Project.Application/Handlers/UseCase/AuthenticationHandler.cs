using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using LocalTrip.Travel.Project.Application.Commands.Request;
using LocalTrip.Travel.Project.Application.Commands.Response;
using LocalTrip.Travel.Project.Application.Core;
using LocalTrip.Travel.Project.Domain.Entities;
using LocalTrip.Travel.Project.Infra.Data.Interfaces;
using LocalTrip.Travel.Project.Infra.Data.Mappers;
using MediatR;

namespace LocalTrip.Travel.Project.Application.Handlers.UseCase
{
    public class AuthenticationHandler : IRequestHandler<AuthenticationCommandRequest,AuthenticationCommandResponse>
    {
        private readonly IApiAccountRepository _apiAccountRepository;

        public AuthenticationHandler(IApiAccountRepository apiAccountRepository)
        {
            _apiAccountRepository = apiAccountRepository;
        }

        public async Task<AuthenticationCommandResponse> Handle(AuthenticationCommandRequest request, CancellationToken cancellationToken)
        {
            var account = OnValidAccountApiData(request.UserCode);
            if (account == null || account.AccessKey == null)
            {
                var ResponseCommandOne = new AuthenticationCommandResponse()
                {
                    Authorized = false
                };
                
                ResponseCommandOne.AddError("Usuario não encontrado, por favor verifique !!!");
                return ResponseCommandOne;
            }

            if (account.AccessKey != request.AccessKey)
            {
                var ResponseCommandTwo = new AuthenticationCommandResponse()
                {
                    Authorized = false
                };
                
                ResponseCommandTwo.AddError("Senha invalida, por favor verifique !!!");
                return ResponseCommandTwo;
            }

            var ResponseCommand = new AuthenticationCommandResponse()
            {
                Authorized = true,
                Errors = { }
            };
            
            return ResponseCommand;
            
        }

        private ApiAccount OnValidAccountApiData(string userCode)
        {
            var result = new ApiAccount(null,null);
            var _result = _apiAccountRepository
                .GetAll().Where(m => m.UserCode == userCode).Single();
            if (_result != null)
            {
                return _result.MapToDomain();
            }

            return result;
        }
    }
}
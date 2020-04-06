using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using LocalTrip.Travel.Project.Application.Commands.Request;
using LocalTrip.Travel.Project.Application.Commands.Response;
using LocalTrip.Travel.Project.Application.Mappers;
using LocalTrip.Travel.Project.Infra.Data.Interfaces;
using LocalTrip.Travel.Project.Infra.Data.Mappers;
using MediatR;

namespace LocalTrip.Travel.Project.Application.Handlers.UseCase
{
    public class AccountRegisterHandler : IRequestHandler<AccountRegisterCommandRequest,AccountRegisterCommandResponse>
    {

        private readonly IPeopleRepository _peopleRepository;
        private readonly IPeopleContactRepository _peopleContactRepository;
        private readonly IPeopleAccountRepository _peopleAccountRepository;
        
        public AccountRegisterHandler(IPeopleRepository peopleRepository, IPeopleContactRepository peopleContactRepository, IPeopleAccountRepository peopleAccountRepository)
        {
            _peopleRepository = peopleRepository;
            _peopleContactRepository = peopleContactRepository;
            _peopleAccountRepository = peopleAccountRepository;
        }

        public async Task<AccountRegisterCommandResponse> Handle(AccountRegisterCommandRequest request, CancellationToken cancellationToken)
        {
            
            var response = new AccountRegisterCommandResponse();
            
            var _result = await SavePeopleDataAsync(request);

            if (!string.IsNullOrEmpty(_result))
                response.AddError(_result);
            
            return response;
        }

        private async Task<string> SavePeopleDataAsync(AccountRegisterCommandRequest request)
        {
            var people = _peopleRepository.GetAllAsync().Result.Where(m => m.Document == request.Document)
                .ToList();

            if (people.Count > 0)
                return "Cliente já cadastrado !!!";
            
            try
            {
                var entity = request.MapToDomain();
                _peopleRepository.Add(entity.MapToDto());
            }
            catch (Exception Ex)
            {

            }

            return null;
        }
    }
}
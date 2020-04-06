using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using LocalTrip.Travel.Project.Application.Commands.Request;
using LocalTrip.Travel.Project.Application.Commands.Response;
using LocalTrip.Travel.Project.Domain.Entities;
using LocalTrip.Travel.Project.Infra.Data.Interfaces;
using LocalTrip.Travel.Project.Infra.Data.Mappers;
using MediatR;

namespace LocalTrip.Travel.Project.Application.Handlers.UseCase
{
    public class AccountDetailHandler : IRequestHandler<AccountDetailCommandRequest,AccountDetailCommandResponse>
    {
        private readonly IPeopleRepository _peopleRepository;
        private readonly IPeopleAccountRepository _peopleAccountRepository;
        private readonly IPeopleContactRepository _peopleContactRepository;

        public AccountDetailHandler(IPeopleRepository peopleRepository, IPeopleAccountRepository peopleAccountRepository
            , IPeopleContactRepository peopleContactRepository)
        {
            _peopleRepository = peopleRepository;
            _peopleAccountRepository = peopleAccountRepository;
            _peopleContactRepository = peopleContactRepository;
        }

        public async Task<AccountDetailCommandResponse> Handle(AccountDetailCommandRequest request, CancellationToken cancellationToken)
        {
            var response = new AccountDetailCommandResponse();

            var result = await GetUseByDocumentNumberAsync(request.Document);

            if (string.IsNullOrEmpty(result.Document))
            {
                response.AddError("Usuario não encontrado, por favor verifique !!!");
                return response;    
            }
            
            response.Result = result;
            
            return response;

            
        }

        private async Task<People> GetUseByDocumentNumberAsync(string document)
        {
            var result = _peopleRepository.GetAllAsync().Result.Where(m => m.Document == document)
                .SingleOrDefault();
            var entity = result.MapToDomain();

            if (!string.IsNullOrEmpty(entity.Document))
            {
                entity.AddAccount(await GetPeopleAccountByPeopleId(result.Id));
                foreach (var contact in await GetAllPeopleContactByPeopleId(result.Id))
                {
                    entity.AddContact(contact);
                }
            }
            
            return entity;
        }

        private async Task<PeopleAccount> GetPeopleAccountByPeopleId(int peopleId)
        {
            var result = _peopleAccountRepository.GetAllAsync().Result.Where(m => m.PeopleId == peopleId)
                .SingleOrDefault();
            return result.MapToDomain();
        }

        private async Task<List<PeopleContact>> GetAllPeopleContactByPeopleId(int peopleId)
        {
            var listresult = new List<PeopleContact>();

            foreach (var contact in _peopleContactRepository.GetAllAsync().Result.Where(m => m.PeopleId == peopleId))
            {
                listresult.Add(contact.MapToDomain());
            }
            
            return listresult;
        }
    }
}
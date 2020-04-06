using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using LocalTrip.Travel.Project.Application.Commands.Request;
using LocalTrip.Travel.Project.Application.Commands.Response;
using LocalTrip.Travel.Project.Domain.Entities;
using LocalTrip.Travel.Project.Domain.Enuns;
using LocalTrip.Travel.Project.Infra.Data.Interfaces;
using LocalTrip.Travel.Project.Infra.Data.Mappers;
using MediatR;

namespace LocalTrip.Travel.Project.Application.Handlers.UseCase
{
    public class AccountUpdateHandler : IRequestHandler<AccountUpdateCommandRequest,AccountUpdateCommandResponse>
    {
        private readonly IPeopleRepository _peopleRepository;
        private readonly IPeopleAccountRepository _peopleAccountRepository;
        private readonly IPeopleContactRepository _peopleContactRepository;

        public AccountUpdateHandler(IPeopleRepository peopleRepository, IPeopleAccountRepository peopleAccountRepository
            , IPeopleContactRepository peopleContactRepository)
        {
            _peopleRepository = peopleRepository;
            _peopleAccountRepository = peopleAccountRepository;
            _peopleContactRepository = peopleContactRepository;
        }
        
        public async Task<AccountUpdateCommandResponse> Handle(AccountUpdateCommandRequest request, CancellationToken cancellationToken)
        {
            var entity = await FindPeopleByDocumentAsync(request.Document);
            if (string.IsNullOrEmpty(entity.Document))
            {
                var responseerror = new AccountUpdateCommandResponse();
                responseerror.AddError("Usuario(a) não encontrado, por favor verifique !!!");
                return responseerror;
            }
            var response = new AccountUpdateCommandResponse();
            
            await UpdatePeopleContactPhoneTypeAsync(request.Document, request.Phone);

            await UpdatePeopleContactEmailTypeAsync(request.Document, request.Email);

            await UpdatePeopleByFilterDocument(request.Document, request.FirstName, request.LastName, request.Type);

            return response;
        }

        private async Task<People> FindPeopleByDocumentAsync(string document)
        {
            var result = _peopleRepository.GetAllAsync().Result.Where(m => m.Document == document).SingleOrDefault();
            var entity = result.MapToDomain();
            
            return entity;
        }

        private async Task UpdatePeopleContactPhoneTypeAsync(string document, string phone)
        {
            var result = _peopleRepository.GetAllAsync().Result.Where(m => m.Document == document).Single();
            var resultchanges = _peopleContactRepository.GetAllAsync()
                .Result.Where(m => m.PeopleId == result.Id && m.ContactType == (int) ContactType.Phone)
                .SingleOrDefault();
            if (resultchanges != null)
                resultchanges.Value = phone;
            _peopleContactRepository.Update(resultchanges);
        }

        private async Task UpdatePeopleContactEmailTypeAsync(string document, string email)
        {
            var result = _peopleRepository.GetAllAsync().Result.Where(m => m.Document == document).Single();
            var resultchanges = _peopleContactRepository.GetAllAsync()
                .Result.Where(m => m.PeopleId == result.Id && m.ContactType == (int) ContactType.Email)
                .SingleOrDefault();
            if (resultchanges != null)
                resultchanges.Value = email;
            _peopleContactRepository.Update(resultchanges);
        }

        private async Task UpdatePeopleByFilterDocument(string document, string firstname, string lastname,PeopleType type)
        {
            var result = _peopleRepository.GetAllAsync().Result.Where(m => m.Document == document).Single();
            result.FirstName = firstname;
            result.LastName = lastname;
            result.PeopleType = (int)type;
            _peopleRepository.Update(result);
        }
    }
}
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using LocalTrip.Travel.Project.Application.Commands.Request;
using LocalTrip.Travel.Project.Application.Commands.Response;
using LocalTrip.Travel.Project.Domain.Enuns;
using LocalTrip.Travel.Project.Infra.Data.Interfaces;
using MediatR;

namespace LocalTrip.Travel.Project.Application.Handlers.UseCase
{
    public class AccountLoginHandler : IRequestHandler<AccountLoginCommandRequest,AccountLoginCommandResponse>
    {
        private readonly IPeopleRepository _peopleRepository;
        private readonly IPeopleAccountRepository _peopleAccountRepository;
        private readonly IPeopleContactRepository _peopleContactRepository;
        
        public AccountLoginHandler(IPeopleRepository peopleRepository, IPeopleAccountRepository peopleAccountRepository
            , IPeopleContactRepository peopleContactRepository)
        {
            _peopleRepository = peopleRepository;
            _peopleAccountRepository = peopleAccountRepository;
            _peopleContactRepository = peopleContactRepository;
        }
        
        public async Task<AccountLoginCommandResponse> Handle(AccountLoginCommandRequest request, CancellationToken cancellationToken)
        {
            
            var validEmail = await ValidEmailAuthenticationAsync(request.Email);
            
            if (!validEmail)
            {
                var _errormail = new AccountLoginCommandResponse();
                _errormail.AddError("Email nao encontrado, por favor verifique !!!");
                _errormail.Result = new 
                {
                    ValidAuthentication = false
                };
                return _errormail;
            }

            var validPassword = await ValidPasswordAuthenticationAsync(request.Email, request.Password);
            if (!validPassword)
            {
                var _errorpass = new AccountLoginCommandResponse();
                _errorpass.AddError("A senha esta incorreta, por favor verifique !!!");
                _errorpass.Result = new 
                {
                    ValidAuthentication = false
                };
                return _errorpass;
            }
            
            var response = new AccountLoginCommandResponse();
            response.Result = new 
            {
                ValidAuthentication = true
            };
            return response;
            
        }

        private async Task<bool> ValidPasswordAuthenticationAsync(string email,string password)
        {
            var result = _peopleContactRepository.GetAllAsync().Result.Where(m => m.Value == email && m.ContactType == (int)ContactType.Email).FirstOrDefault();
            
            var validpassword = _peopleAccountRepository.GetAllAsync().Result
                .Where(m => m.PeopleId == result.PeopleId && m.Password == password).FirstOrDefault();
            
            if (validpassword == null)
                return false;
            
            return true;
        }

        private async Task<bool> ValidEmailAuthenticationAsync(string email)
        {
            var result = _peopleContactRepository.GetAllAsync().Result.Where(m => m.Value == email && m.ContactType == (int)ContactType.Email).FirstOrDefault();
            
            if (result == null)
                return false;
            
            return true;
        }
    }
}
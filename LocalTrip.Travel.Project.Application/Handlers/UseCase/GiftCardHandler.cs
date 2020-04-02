using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using LocalTrip.Travel.Project.Application.Commands.Request;
using LocalTrip.Travel.Project.Application.Commands.Response;
using LocalTrip.Travel.Project.Infra.Data.Interfaces;
using MediatR;

namespace LocalTrip.Travel.Project.Application.Handlers.UseCase
{
    public class GiftCardHandler : IRequestHandler<GiftCardByDayCommandRequest,GiftCardByDayCommandResponse>
    {
        private readonly IGiftCardRepository _giftCardRepository;

        public GiftCardHandler(IGiftCardRepository giftCardRepository)
        {
            _giftCardRepository = giftCardRepository;
        }
        
        public async Task<GiftCardByDayCommandResponse> Handle(GiftCardByDayCommandRequest request, CancellationToken cancellationToken)
        {
            
            var ResultResponse = _giftCardRepository.GetAllAsync().Result
                .Where(m => m.ValidDate == DateTime.Now).ToList();
            if (ResultResponse == null)
            {
                var _resultOne = new GiftCardByDayCommandResponse();
                _resultOne.AddError("Dados não encontrado, por favor verifique !!!");
                return _resultOne;
            }
            var _result = new GiftCardByDayCommandResponse();
            _result.Result = ResultResponse;
            return _result;

        }
    }
}
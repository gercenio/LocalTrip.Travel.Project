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

        public Task<GiftCardByDayCommandResponse> Handle(GiftCardByDayCommandRequest request, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
            var ResultResponse = _giftCardRepository.GetAll()
                .Where(m => m.ValidDate == DateTime.Now).ToList();
            
        }
    }
}
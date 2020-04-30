using System.Threading;
using System.Threading.Tasks;
using LocalTrip.Travel.Project.Application.Commands.Request;
using LocalTrip.Travel.Project.Application.Commands.Response;
using LocalTrip.Travel.Project.Domain.Entities;
using LocalTrip.Travel.Project.Infra.Data.Interfaces;
using MediatR;

namespace LocalTrip.Travel.Project.Application.Handlers.UseCase
{
    public class RemoveCartItemHandler : IRequestHandler<RemoveCartItemCommandRequest,RemoveCartItemCommandResponse>
    {
        private readonly ICartItemRepository _cartItemRepository;

        public RemoveCartItemHandler(ICartItemRepository cartItemRepository)
        {
            _cartItemRepository = cartItemRepository;
        }
        
        public async Task<RemoveCartItemCommandResponse> Handle(RemoveCartItemCommandRequest request, CancellationToken cancellationToken)
        {
            var response = new RemoveCartItemCommandResponse();

            await RemoveCartItemByIdAsync(request.CartItemId);
            
            return response;

        }

        private async Task RemoveCartItemByIdAsync(int id)
        {
            var entity = _cartItemRepository.GetById(id);
            _cartItemRepository.Remove(entity);
        }
    }
}
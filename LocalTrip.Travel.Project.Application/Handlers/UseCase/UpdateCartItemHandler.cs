using System.Threading;
using System.Threading.Tasks;
using LocalTrip.Travel.Project.Application.Commands.Request;
using LocalTrip.Travel.Project.Application.Commands.Response;
using LocalTrip.Travel.Project.Infra.Data.Interfaces;
using MediatR;

namespace LocalTrip.Travel.Project.Application.Handlers.UseCase
{
    public class UpdateCartItemHandler : IRequestHandler<UpdateCartItemCommandRequest,UpdateCartItemCommandResponse>
    {
        private readonly ICartItemRepository _cartItemRepository;

        public UpdateCartItemHandler(ICartItemRepository cartItemRepository)
        {
            _cartItemRepository = cartItemRepository;
        }
        
        public async Task<UpdateCartItemCommandResponse> Handle(UpdateCartItemCommandRequest request, CancellationToken cancellationToken)
        {
            var response = new UpdateCartItemCommandResponse();

            await UpdateCartItemAsync(request.CartItemId, request.Count);
            
            return response;
        }

        private async Task UpdateCartItemAsync(int cartItemId, int count)
        {
            var entity = _cartItemRepository.GetById(cartItemId);
            entity.Count = count;
            _cartItemRepository.Update(entity);
        }
    }
}
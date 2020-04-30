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
    public class GetCartItemByCartIdHandler : IRequestHandler<GetCartItemByCartIdCommandRequest,GetCartItemByCartIdCommandResponse>
    {
        private readonly ICartRepository _cartRepository;
        private readonly ICartItemRepository _cartItemRepository;
        private readonly IPeopleRepository _peopleRepository;
        private readonly IDestinationRepository _destinationRepository;

        public GetCartItemByCartIdHandler(ICartRepository cartRepository, ICartItemRepository cartItemRepository,IPeopleRepository peopleRepository,IDestinationRepository destinationRepository)
        {
            _cartRepository = cartRepository;
            _cartItemRepository = cartItemRepository;
            _peopleRepository = peopleRepository;
            _destinationRepository = destinationRepository;
        }

        public async Task<GetCartItemByCartIdCommandResponse> Handle(GetCartItemByCartIdCommandRequest request, CancellationToken cancellationToken)
        {
            var response = new GetCartItemByCartIdCommandResponse();
            response.Result = GetCartByCartIdAsync(request.CartId);
            
            return response;
        }

        private async Task<Cart> GetCartByCartIdAsync(int cartId)
        {
            var cart = _cartRepository.GetById(cartId).MapToDomain();
            
            if(cart == null)
                return new Cart(0,0);
            
            foreach (var item in _cartItemRepository.GetAllAsync(0,1,(m => m.CartId == cartId)).Result.Item1.ToList())
            {
                var entityItem = item.MapToDomain();
                entityItem.AddDestination(await GetDestinationById(item.DestinationId));
                cart.AddItem(entityItem);
            }

            cart.AddPeople(await GetPeopleByIdAsync(cart.PeopleId));
            
            return cart;
        }

        private async Task<People> GetPeopleByIdAsync(int peopleId)
        {
            var entity = _peopleRepository.GetById(peopleId);
            return entity.MapToDomain();
        }

        private async Task<Destination> GetDestinationById(int id)
        {
            var entity = _destinationRepository.GetById(id);
            return entity.MapToDomain();
        }
    }
}
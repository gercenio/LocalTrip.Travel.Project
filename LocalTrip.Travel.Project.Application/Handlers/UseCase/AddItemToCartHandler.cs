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
    public class AddItemToCartHandler : IRequestHandler<AddItemToCartCommandRequest,AddItemToCartCommandResponse>
    {
        
        private readonly ICartRepository _cartRepository;
        private readonly ICartItemRepository _cartItemRepository;
        private readonly IPeopleRepository _peopleRepository;
        private readonly IDestinationRepository _destinationRepository;

        public AddItemToCartHandler(ICartRepository cartRepository, ICartItemRepository cartItemRepository,IPeopleRepository peopleRepository,IDestinationRepository destinationRepository)
        {
            _cartRepository = cartRepository;
            _cartItemRepository = cartItemRepository;
            _peopleRepository = peopleRepository;
            _destinationRepository = destinationRepository;
        }

        public async Task<AddItemToCartCommandResponse> Handle(AddItemToCartCommandRequest request, CancellationToken cancellationToken)
        {

            var response = new AddItemToCartCommandResponse();
            
            var peopleEntity = await FindPeopleById(request.PeopleId);

            if (string.IsNullOrEmpty(peopleEntity.Document))
            {
                response.AddError("Cliente nao encontrado, por favor verifique !!!");
                return response;
            }

            var destinationEntity = await FindDestinationById(request.DestinationId);
            if (string.IsNullOrEmpty(destinationEntity.Name))
            {
                response.AddError("Destino não encontrado, por favor verifique !!!");
                return response;
            }

            return response;
        }

        private async Task<People> FindPeopleById(int PeopleId)
        {
            var peopleEntity = _peopleRepository.GetAllAsync(0, 1, (m => m.Id == PeopleId)).Result.Item1
                .SingleOrDefault();
            if(peopleEntity == null)
                return new People(string.Empty,string.Empty,string.Empty);
            
            return peopleEntity.MapToDomain();
        }

        private async Task<Destination> FindDestinationById(int DestinationId)
        {
            var destinationEntity = _destinationRepository.GetAllAsync(0, 1, (m => m.Id == DestinationId)).Result.Item1
                .SingleOrDefault();
            
            if(destinationEntity == null)
                return new Destination(string.Empty,0,string.Empty,string.Empty,string.Empty,string.Empty);

            return destinationEntity.MapToDomain();
        }
    }
}
using LocalTrip.Travel.Project.Application.Commands.Response;
using MediatR;

namespace LocalTrip.Travel.Project.Application.Commands.Request
{
    public class AddItemToCartCommandRequest : IRequest<AddItemToCartCommandResponse>
    {
        public int CartId { get; }
        public int DestinationId { get; }
        public int PeopleId { get; }
        public int Count { get;  }

        public AddItemToCartCommandRequest(int cartId, int destinationId, int peopleId, int count)
        {
            CartId = cartId;
            DestinationId = destinationId;
            PeopleId = peopleId;
            Count = count;
        }
    }
}
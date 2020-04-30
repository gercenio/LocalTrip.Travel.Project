using LocalTrip.Travel.Project.Application.Commands.Response;
using MediatR;

namespace LocalTrip.Travel.Project.Application.Commands.Request
{
    public class RemoveCartItemCommandRequest : IRequest<RemoveCartItemCommandResponse>
    {
        public int CartItemId { get; }

        public RemoveCartItemCommandRequest(int cartItemId)
        {
            CartItemId = cartItemId;
        }

    }
}
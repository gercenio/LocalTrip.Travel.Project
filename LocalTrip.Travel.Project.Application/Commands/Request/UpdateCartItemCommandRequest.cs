using LocalTrip.Travel.Project.Application.Commands.Response;
using MediatR;

namespace LocalTrip.Travel.Project.Application.Commands.Request
{
    public class UpdateCartItemCommandRequest : IRequest<UpdateCartItemCommandResponse>
    {
        public int CartItemId { get; }
        public int Count { get; }

        public UpdateCartItemCommandRequest(int cartItemId,int count)
        {
            CartItemId = cartItemId;
            Count = count;
        }

    }
}
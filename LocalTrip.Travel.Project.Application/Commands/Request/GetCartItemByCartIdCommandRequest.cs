using LocalTrip.Travel.Project.Application.Commands.Response;
using MediatR;

namespace LocalTrip.Travel.Project.Application.Commands.Request
{
    public class GetCartItemByCartIdCommandRequest :IRequest<GetCartItemByCartIdCommandResponse>
    {
        public int CartId { get; }

        public GetCartItemByCartIdCommandRequest(int cartId)
        {
            CartId = cartId;
        }
    }
}
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using LocalTrip.Travel.Project.Application.Commands.Request;
using LocalTrip.Travel.Project.Application.Commands.Response;
using LocalTrip.Travel.Project.Infra.Data.Interfaces;
using MediatR;

namespace LocalTrip.Travel.Project.Application.Handlers.UseCase
{
    public class GetAllPaymentHandler : IRequestHandler<GetAllPaymentCommandRequest,GetAllPaymentCommandResponse>
    {
        private readonly IPaymentRepository _paymentRepository;

        public GetAllPaymentHandler(IPaymentRepository paymentRepository)
        {
            _paymentRepository = paymentRepository;
        }

        public async Task<GetAllPaymentCommandResponse> Handle(GetAllPaymentCommandRequest request, CancellationToken cancellationToken)
        {
            var response = new GetAllPaymentCommandResponse();
            
            response.Result = _paymentRepository.GetAllAsync().Result.ToList();

            return response;
        }
    }
}
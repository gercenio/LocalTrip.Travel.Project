using System.Threading;
using System.Threading.Tasks;
using LocalTrip.Travel.Project.Application.Commands.Request;
using LocalTrip.Travel.Project.Application.Commands.Response;
using LocalTrip.Travel.Project.Infra.Data.Interfaces;
using MediatR;

namespace LocalTrip.Travel.Project.Application.Handlers.UseCase
{
    public class FindTripHandler : IRequestHandler<FindTripCommandRequest,FindTripCommandResponse>
    {
        private readonly ITripRepository _tripRepository;
        public FindTripHandler(ITripRepository tripRepository)
        {
            _tripRepository = tripRepository;
        }

        public Task<FindTripCommandResponse> Handle(FindTripCommandRequest request, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }
    }
}
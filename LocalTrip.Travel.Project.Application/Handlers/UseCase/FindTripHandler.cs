using System.Collections.Generic;
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
    public class FindTripHandler : IRequestHandler<FindTripCommandRequest,FindTripCommandResponse>
    {
        private readonly IDestinationRepository _destinationRepository;
        public FindTripHandler(IDestinationRepository destinationRepository)
        {
            _destinationRepository = destinationRepository;
        }

        public async Task<FindTripCommandResponse> Handle(FindTripCommandRequest request, CancellationToken cancellationToken)
        {
            var result = await GetDestinationByFilter(request.City, request.Country);
            if (result.Count == 0)
            {
                var erroResult = new FindTripCommandResponse();
                erroResult.AddError("Nenhum dado foi encontrado, por favor verifique !!!");
                return erroResult;    
            }
            var response = new FindTripCommandResponse();
            response.Result = result;
            return response;
        }

        private async Task<List<Destination>> GetDestinationByFilter(string city, string country)
        {
            List<Destination> result = new List<Destination>();
            var resultDb =  _destinationRepository.GetAllAsync().Result
                .Where(m => m.City.ToUpper() == city.ToUpper() 
                            && m.Country.ToUpper() == country.ToUpper()).ToList();
            
            foreach (var entity in resultDb)
            {
                result.Add(entity.MapToDomain());
            }

            return result;
        }
        
    }
}
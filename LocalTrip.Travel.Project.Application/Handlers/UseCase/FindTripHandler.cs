using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using LocalTrip.Travel.Project.Application.Commands.Request;
using LocalTrip.Travel.Project.Application.Commands.Response;
using LocalTrip.Travel.Project.Domain.Entities;
using LocalTrip.Travel.Project.Infra.Data.Interfaces;
using LocalTrip.Travel.Project.Infra.Data.Mappers;
using LocalTrip.Travel.Project.Infra.Service.Interfaces;
using LocalTrip.Travel.Project.Infra.Service.Mappers;
using MediatR;

namespace LocalTrip.Travel.Project.Application.Handlers.UseCase
{
    public class FindTripHandler : IRequestHandler<FindTripCommandRequest,FindTripCommandResponse>
    {
        private readonly IDestinationRepository _destinationRepository;
        private readonly IServiceImage _serviceImage;
        public FindTripHandler(IDestinationRepository destinationRepository,IServiceImage serviceImage)
        {
            _destinationRepository = destinationRepository;
            _serviceImage = serviceImage;
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

            for (int i = 0; i < result.Count; i++)
            {
                var images = await GetAllByDestinationTokenAsync(result[i].TokenImage);
                foreach (var img in images)
                {
                    result[i].AddImage(img);    
                }
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

        private async Task<List<DestinationImage>> GetAllByDestinationTokenAsync(string token)
        {
            var listResult = new List<DestinationImage>();
            var imagesDb = await _serviceImage.GetAllAsync(token);

            foreach (var img in imagesDb.Data.ToList())
            {
                listResult.Add(img.MapToDomain());
            }
            
            return listResult;
        }

    }
}
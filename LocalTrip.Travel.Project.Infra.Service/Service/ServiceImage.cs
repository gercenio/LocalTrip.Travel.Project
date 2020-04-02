using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using LocalTrip.Travel.Project.Infra.Service.Configurations;
using LocalTrip.Travel.Project.Infra.Service.Dtos.ServiceImage;
using LocalTrip.Travel.Project.Infra.Service.Extensions;
using LocalTrip.Travel.Project.Infra.Service.Interfaces;
using Microsoft.Extensions.Options;

namespace LocalTrip.Travel.Project.Infra.Service.Service
{
    public class ServiceImage : IServiceImage
    {
        private readonly ImageServiceSettings _settings;
        private readonly HttpClient _httpClient;
        
        public ServiceImage(IOptions<ImageServiceSettings> options
            , HttpClient httpClient)
        {
            _settings = options.Value;
            _httpClient = httpClient;
        }

        public async Task<BaseImageResponseDto> GetAll(string imagemtoken)
        {
            var (httpResponse, content) = await _httpClient.SendRequestAsync<string,BaseImageResponseDto>(
                    $"{_settings.GetAllByToken}",HttpMethod.Get, "");
            
            if (httpResponse.StatusCode == HttpStatusCode.NotFound)
            {
                return null;
            }

            return content;
            
        }
    }
}
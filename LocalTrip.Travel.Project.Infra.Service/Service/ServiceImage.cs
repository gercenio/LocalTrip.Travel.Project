using System;
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
            _httpClient.BaseAddress = new Uri(_settings.Url);
        }
        public async Task<BaseImageResponseDto> GetAllAsync(string imagemtoken)
        {
            var (httpResponse, content) = await _httpClient.SendRequestAsync<string,BaseImageResponseDto>(
                    $"{_settings.GetAllByToken}/?userToken={imagemtoken}",HttpMethod.Get, "");
            
            if (httpResponse.StatusCode == HttpStatusCode.NotFound)
            {
                return null;
            }
            return content;
            
        }
    }
}
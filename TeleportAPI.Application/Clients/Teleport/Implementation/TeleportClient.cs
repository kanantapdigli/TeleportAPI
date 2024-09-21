using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Mime;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using TeleportAPI.Application.Clients.Teleport.Abstraction;
using TeleportAPI.Application.Dtos.Clients.Teleport.Response;
using TeleportAPI.Application.Wrappers;

namespace TeleportAPI.Application.Clients.Teleport.Implementation
{
    public class TeleportClient : ITeleportClient
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;

        public TeleportClient(IHttpClientFactory httpClientFactory, IConfiguration configuration)
        {
            _httpClient = httpClientFactory.CreateClient();
            _configuration = configuration;
        }

        private string TeleportUrl => _configuration.GetRequiredSection("Clients:TeleportBaseURL")?.Value;
        private JsonSerializerOptions options => new JsonSerializerOptions { PropertyNameCaseInsensitive = true };

        /// <summary>
        /// 
        /// </summary>
        /// <param name="iata"></param>
        public async Task<TeleportIataResponseDto> GetByIataCodeAsync(string iata)
        {
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri($"{TeleportUrl}/{iata}")
            };

            var response = await _httpClient.SendAsync(request);
            return await JsonSerializer.DeserializeAsync<TeleportIataResponseDto>(await response?.Content?.ReadAsStreamAsync(), options);
        }
    }
}

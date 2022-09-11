using AdsProTest.Models;
using System.Text.Json.Serialization;

namespace AdsProTest.Services
{
    public class IpService
    {
        private readonly IpServiceConfiguration _config;
        private readonly HttpClient _httpClient;

        public IpService(IpServiceConfiguration config)
        {
            _config = config;
            _httpClient = new HttpClient();
        }
        public async Task<IpServiceResponse?> GetCountry(string ip)
        {
            var url = $"{_config.ServiceURL}{ip}?access_key={_config.AccessKey}";
            HttpResponseMessage response = await _httpClient.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                return await response.Content?.ReadFromJsonAsync<IpServiceResponse>();
            }
            return null;
        }
    }
}

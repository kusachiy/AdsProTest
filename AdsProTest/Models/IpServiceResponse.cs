using System.Text.Json.Serialization;

namespace AdsProTest.Models
{
    public class IpServiceResponse
    {
        [JsonPropertyName("country_code")]
        public string CountryCode { get; set; }

        [JsonPropertyName("country_name")]
        public string CountryName { get; set; }
    }
}

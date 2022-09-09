using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace AdsProTest.Controllers.RequestModels
{
    public class TrackingRequestModel
    {
        [FromHeader(Name = "Site-IP")]
        [Required(ErrorMessage = "Header Site-IP is required")]
        [RegularExpression(@"\b\d{1,3}\.\d{1,3}\.\d{1,3}\.\d{1,3}\b", ErrorMessage = "'Site-IP' must match the ip address format.")]
        public string SiteIp { get; set; }

        [FromQuery(Name = "token")]
        [Required]
        public string Token { get; set; }

        [FromQuery(Name = "client_ip")]
        [Required]
        [RegularExpression(@"\b\d{1,3}\.\d{1,3}\.\d{1,3}\.\d{1,3}\b", ErrorMessage = "'client_ip' must match the ip address format.")]
        public string ClientIP { get; set; }

        [FromQuery(Name = "domain")]
        [Required]
        public string Domain { get; set; }

        [FromQuery(Name = "os")]
        [Required(AllowEmptyStrings = false)]
        public string OS { get; set; }

        [FromQuery(Name = "client_id")]
        [Required]
        public Guid ClientId { get; set; }
    }
}
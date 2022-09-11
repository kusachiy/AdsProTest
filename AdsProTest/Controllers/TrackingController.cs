using AdsProTest.Controllers.RequestModels;
using AdsProTest.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AdsProTest.Controllers
{
    [Route("feed")]
    [ApiController]
    public class TrackingController : ControllerBase
    {
        private readonly TrackedRequestService _requestService;
        private readonly IpService _ipService;


        public TrackingController(TrackedRequestService requestService, IpService ipService)
        {
            _requestService = requestService;
            _ipService = ipService;
        }
        // GET
        [HttpGet]
        public async Task<ActionResult> Get([FromServices] ApiConfiguration apiConfiguration, [FromQuery] TrackingRequestModel requestData)
        {
            if (requestData.Token != apiConfiguration.RequestToken)
                return Unauthorized("Wrong access token");
            if (!apiConfiguration.PermittedOS.Contains(requestData.OS))
            {
                ModelState.AddModelError("OS", "OS value is not allowed");
                return BadRequest(ModelState);
            }
            if (await _requestService.ContainsClientId(requestData.ClientId.ToString()))
                return Ok("Duplicate");
            var clientCountry = (await _ipService.GetCountry(requestData.ClientIP))?.CountryCode;
            var siteCountry = (await _ipService.GetCountry(requestData.SiteIp))?.CountryCode;
            await _requestService.InsertRequest(
                new Models.TrackedRequest
                {
                    ClientCountry = clientCountry,
                    ClientId = requestData.ClientId.ToString(),
                    ClientIp = requestData.ClientIP,
                    OS = requestData.OS,
                    SiteCountry = siteCountry,
                    Domain = requestData.Domain
                });
            return Ok("Success");
        }

    }
}

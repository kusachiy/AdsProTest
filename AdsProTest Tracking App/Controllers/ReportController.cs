using AdsProTest.Controllers.RequestModels;
using AdsProTest.Models;
using AdsProTest.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AdsProTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportController : ControllerBase
    {
        private readonly TrackedRequestService _requestService;

        public ReportController(TrackedRequestService requestService)
        {
            _requestService = requestService;
        }
        [HttpGet("byrequest")]
        public async Task<List<TrackedRequest>> GetByRequest()
        {
            return  await _requestService.GetRequests();
        }
        [HttpGet("bycountry")]
        public async Task<List<TrackedRequestGroupByCountry>> GetByCountry()
        {
            return await _requestService.GetRequestsByCountry();
        }
    }
}

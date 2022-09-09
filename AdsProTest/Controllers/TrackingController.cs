using AdsProTest.Controllers.RequestModels;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AdsProTest.Controllers
{
    [Route("feed")]
    [ApiController]
    public class TrackingController : ControllerBase
    {
        // GET
        [HttpGet]
        public ActionResult Get([FromServices] ApiConfiguration apiConfiguration, [FromQuery] TrackingRequestModel requestData)
        {
            if (requestData.Token != apiConfiguration.RequestToken)
                return Unauthorized("Wrong access token");
            if (!apiConfiguration.PermittedOS.Contains(requestData.OS))
            {
                ModelState.AddModelError("OS", "OS value is not allowed");
                return BadRequest(ModelState);
            }
            return Ok();
        }

    }
}

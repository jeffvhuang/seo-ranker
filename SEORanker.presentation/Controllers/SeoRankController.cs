using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace SEORanker.presentation.Controllers
{
    [Produces("application/json")]
    [Route("api")]
    [ApiController]
    public class SeoRankController : ControllerBase
    {
        private readonly ILogger<SeoRankController> _logger;

        public SeoRankController(ILogger<SeoRankController> logger)
        {
            _logger = logger;
        }

        //[HttpPost("rankseo")]
        //[ProducesResponseType(typeof(SeoRanksVM), StatusCodes.Status201Created)]
        //public IActionResult CalculateTrolley(SeoRanksVM trolley)
        //{

        //}
    }
}

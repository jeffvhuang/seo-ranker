using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SEORanker.domain.Managers;
using SEORanker.presentation.RequestModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SEORanker.presentation.Controllers
{
    [Produces("application/json")]
    [Route("api")]
    [ApiController]
    public class SeoRankController : ControllerBase
    {
        private readonly ISeoRankManager _manager;

        public SeoRankController(ISeoRankManager manager)
        {
            _manager = manager;
        }

        [HttpPost("rank")]
        [ProducesResponseType(typeof(List<int>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetSeoRanks(SeoRankSearch searchParams)
        {
            var numbers = await _manager.GetRanks(searchParams.Search, searchParams.Url);
            return Ok(numbers);
        }
    }
}

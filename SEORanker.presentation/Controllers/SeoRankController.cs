using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SEORanker.domain.Managers;
using SEORanker.presentation.RequestModels;
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

        [HttpPost("search")]
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetSearchContent(SeoRankSearch searchParams)
        {
            var content = await _manager.GetSearchContent(searchParams.Search);
            return Ok(content);
        }
    }
}

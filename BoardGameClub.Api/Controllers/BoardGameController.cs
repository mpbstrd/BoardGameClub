using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BoardGameClub.Api.Controllers
{
    [Route("api/board-game")]
    [ApiController]
    public class BoardGameController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(new
            {
                data = "Hello World"
            });
        }
    }
}

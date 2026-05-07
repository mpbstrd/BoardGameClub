using BoardGameClub.Application.Features.BoardGames.GetGames;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BoardGameClub.Api.Controllers
{
    [Route("api/board-game")]
    [ApiController]
    public class BoardGameController : ControllerBase
    {
        private readonly IMediator _mediator;

        public BoardGameController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await _mediator.Send(new GetGamesQuery());
            return Ok(result);
        }
    }
}
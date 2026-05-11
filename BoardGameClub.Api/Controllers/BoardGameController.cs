using BoardGameClub.Application.Features.BoardGames.GetGames;
using BoardGameClub.Application.Interfaces;
using BoardGameClub.Infrastructure.Services;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BoardGameClub.Api.Controllers
{
    [Route("api/board-game")]
    [ApiController]
    public class BoardGameController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IBggService _bggService;

        public BoardGameController(IMediator mediator, IBggService bggService)
        {
            _mediator = mediator;
            _bggService = bggService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await _mediator.Send(new GetGamesQuery());
            return Ok(result);
        }

        [HttpGet("bgg/{id}")]
        public async Task<IActionResult> GetBggGame(int id)
        {
            var game = await _bggService.GetGameAsync(id);

            if (game == null)
                return NotFound();

            return Ok(game);
        }

        [HttpGet("bgg/categories")]
        public async Task<IActionResult> GetBggCategories()
        {
            var game = await _bggService.GetCategoriesAsync();

            if (game == null)
                return NotFound();

            return Ok(game);
        }
    }
}
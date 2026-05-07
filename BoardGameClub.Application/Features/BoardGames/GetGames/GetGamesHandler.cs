using BoardGameClub.Application.Interfaces;
using BoardGameClub.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace BoardGameClub.Application.Features.BoardGames.GetGames
{
    public class GetGamesHandler : IRequestHandler<GetGamesQuery, List<BoardGame>>
    {
        private readonly IBoardGameRepository _repo;

        public GetGamesHandler(IBoardGameRepository repo)
        {
            _repo = repo;
        }

        public async Task<List<BoardGame>> Handle(GetGamesQuery request, CancellationToken cancellationToken)
        {
            var games = await _repo.GetAllAsync();
            return games;
        }
    }
}

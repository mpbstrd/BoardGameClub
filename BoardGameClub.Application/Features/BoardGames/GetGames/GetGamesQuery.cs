using BoardGameClub.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace BoardGameClub.Application.Features.BoardGames.GetGames
{
    public class GetGamesQuery : IRequest<List<BoardGame>>
    {
    }
}

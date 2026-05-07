using BoardGameClub.Application.Interfaces;
using BoardGameClub.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using DomainBoardGame = BoardGameClub.Domain.Entities.BoardGame;
using DbBoardGame = BoardGameClub.Infrastructure.Persistence.Scaffolded.BoardGame;

namespace BoardGameClub.Infrastructure.Repositories
{
    public class BoardGameRepository : IBoardGameRepository
    {
        private readonly AppDbContext _context;
        public BoardGameRepository(AppDbContext context) 
        { 
            _context = context;
        }

        public async Task<List<DomainBoardGame>> GetAllAsync()  
        {
            List<DbBoardGame> result = await _context.BoardGames.ToListAsync();

            return [.. result.Select(record => new DomainBoardGame
            {
                Id = record.Id,
                PublicId = record.PublicId,
                Name = record.Name,
                Weight = (float)record.Weight,
                MinimumPlayers = record.MinPlayers,
                MaximumPlayers = record.MaxPlayers,
                MaximumDuration = (int)record.Duration,
                BggId = (int)record.BggId,
                CreatedAt = record.CreatedAt
            })];
        }

        public async Task<DomainBoardGame?> GetByIdAsync(Guid id)
        {
            DbBoardGame? record = await _context.BoardGames.FindAsync(id);

            if (record == null)
                return null;

            return new DomainBoardGame
            {
                Id = record.Id,
                PublicId = record.PublicId,
                Name = record.Name,
                Weight = (float)record.Weight,
                MinimumPlayers = record.MinPlayers,
                MaximumPlayers = record.MaxPlayers,
                MaximumDuration = (int)record.Duration,
                BggId = (int)record.BggId,
                CreatedAt = record.CreatedAt
            };
        }
    }
}

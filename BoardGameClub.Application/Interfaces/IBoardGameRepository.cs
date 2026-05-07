using BoardGameClub.Domain.Entities;

namespace BoardGameClub.Application.Interfaces
{
    public interface IBoardGameRepository
    {
        Task<BoardGame?> GetByIdAsync(Guid id);
        Task<List<BoardGame>> GetAllAsync();
        //Task CreateAsync(BoardGame boardGame);
    }
}

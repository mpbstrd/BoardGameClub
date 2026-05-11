using BoardGameClub.Application.DTOs;

namespace BoardGameClub.Application.Interfaces
{
    public interface IBggService
    {
        Task<BggGameDto?> GetGameAsync(int id);
    }
}
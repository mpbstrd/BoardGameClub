using BoardGameClub.Domain.Entities;

namespace BoardGameClub.Application.Interfaces
{
    public interface IMemberRepository
    {
        Task<Member?> GetByIdAsync(Guid id);
    }
}

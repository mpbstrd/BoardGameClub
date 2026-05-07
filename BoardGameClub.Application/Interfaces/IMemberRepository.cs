using BoardGameClub.Domain.Entities;

namespace BoardGameClub.Application.Interfaces
{
    public interface IMemberRepository
    {
        Task<Member?> GetByIdAsync(Guid id);
        Task<List<Member>> GetAllAsync();
        Task CreateMemberAsync(Member member);
    }
}

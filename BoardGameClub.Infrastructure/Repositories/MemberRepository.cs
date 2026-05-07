using BoardGameClub.Application.Interfaces;
using BoardGameClub.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using DomainMember = BoardGameClub.Domain.Entities.Member;
using DbMember = BoardGameClub.Infrastructure.Persistence.Scaffolded.Member;


namespace BoardGameClub.Infrastructure.Repositories
{
    public class MemberRepository : IMemberRepository
    {
        private readonly AppDbContext _context;

        public MemberRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<DomainMember>> GetAllAsync()
        {
           List<DbMember> records = await _context.Members.Where(x => x.Status == "active").ToListAsync();

            return [.. records.Select(record => new DomainMember
            {
                Id = record.Id,
                PublicId = record.PublicId,
                Name = record.Name,
                Status = (record.Status ?? "active") == "active",
                CreatedAt = record.CreatedAt,
                UpdatedAt = record.UpdatedAt
            })];
        }

        public async Task<DomainMember?> GetByIdAsync(Guid id)
        {
            DbMember? record = await _context.Members.FindAsync(id);

            if (record == null)
                return null;

            return new DomainMember
            {
                Id = record.Id,
                PublicId = record.PublicId,
                Name = record.Name,
                Status = (record.Status ?? "active") == "active",
                CreatedAt = record.CreatedAt,
                UpdatedAt = record.UpdatedAt
            };
        }

        public async Task CreateAsync(DomainMember member)
        {
            var dbMember = new DbMember
            {
                Id = member.Id,
                PublicId = member.PublicId,
                Name = member.Name,
                Status = member.Status ? "active" : "inactive",
                CreatedAt = member.CreatedAt,
                UpdatedAt = member.UpdatedAt
            };

            _context.Members.Add(dbMember);
            await _context.SaveChangesAsync();
        }
    }
}

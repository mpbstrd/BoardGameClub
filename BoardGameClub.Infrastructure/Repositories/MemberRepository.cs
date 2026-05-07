using BoardGameClub.Application.Interfaces;
using BoardGameClub.Infrastructure.DependencyInjection;
using BoardGameClub.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Text;
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
    }
}

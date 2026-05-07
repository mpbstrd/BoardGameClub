using BoardGameClub.Application.Interfaces;
using BoardGameClub.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace BoardGameClub.Application.Features.Members.CreateMember
{
    public class CreateMemberHandler : IRequestHandler<CreateMemberCommand, int>
    {
        private readonly IMemberRepository _repo;

        public CreateMemberHandler(IMemberRepository repo)
        {
            _repo = repo;
        }

        public async Task<int> Handle(CreateMemberCommand request, CancellationToken cancellationToken)
        {
            var member = new Member
            {
                Name = request.Name,
                Status = true
            };

            await _repo.CreateMemberAsync(member);

            return member.Id;
        }
    }
}

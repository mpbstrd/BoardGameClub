using BoardGameClub.Application.Interfaces;
using BoardGameClub.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace BoardGameClub.Application.Features.Members.GetMemberById
{
    public class GetMemberByIdHandler : IRequestHandler<GetMemberByIdQuery, Member>
    {
        private readonly IMemberRepository _repo;

        public GetMemberByIdHandler(IMemberRepository repo)
        {
            _repo = repo;
        }

        public async Task<Member> Handle(GetMemberByIdQuery request, CancellationToken cancellationToken)
        {
            var member = await _repo.GetByIdAsync(request.Id);

            if (member == null)
                return null;

            return new Member
            {
                Id = member.Id,
                Name = member.Name
            };
        }
    }
}

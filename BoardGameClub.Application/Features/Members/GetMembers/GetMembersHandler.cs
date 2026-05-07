using BoardGameClub.Application.Interfaces;
using BoardGameClub.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace BoardGameClub.Application.Features.Members.GetMembers
{
    public class GetMembersHandler : IRequestHandler<GetMembersQuery, List<Member>>
    {
        private readonly IMemberRepository _repo;

        public GetMembersHandler(IMemberRepository repo)
        {
            _repo = repo;
        }

        public async Task<List<Member>> Handle(GetMembersQuery request, CancellationToken cancellationToken)
        {
            var members = await _repo.GetAllAsync();
            return members;
        }
    }
}

using BoardGameClub.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace BoardGameClub.Application.Features.Members.CreateMember
{
    public class CreateMemberCommand : IRequest<int>
    {
        public required string Name { get; set; }
    }
}

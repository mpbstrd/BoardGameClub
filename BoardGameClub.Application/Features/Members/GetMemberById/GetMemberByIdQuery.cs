using BoardGameClub.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace BoardGameClub.Application.Features.Members.GetMemberById
{
    public class GetMemberByIdQuery : IRequest<Member>
    {
        public Guid Id { get; set; }
    }
}

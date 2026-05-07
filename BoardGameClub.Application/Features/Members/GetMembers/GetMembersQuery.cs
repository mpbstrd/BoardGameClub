using BoardGameClub.Domain.Entities;
using MediatR;

namespace BoardGameClub.Application.Features.Members.GetMembers
{
    public class GetMembersQuery : IRequest<List<Member>>
    {
    }
}

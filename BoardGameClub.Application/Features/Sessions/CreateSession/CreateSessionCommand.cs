using System;
using System.Collections.Generic;
using System.Text;
using MediatR;

namespace BoardGameClub.Application.Features.Sessions.CreateSession
{
    public class CreateSessionCommand : IRequest<Guid>
    {
        public Guid HostMemberId { get; set; }
        public Guid BoardGameId { get; set; }
        public Guid LocationId { get; set; }
        public DateTime ScheduledDate { get; set; }
        public int MaxPlayers { get; set; }
        public string? Notes { get; set; }
    }
}

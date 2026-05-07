using System;
using System.Collections.Generic;

namespace BoardGameClub.Infrastructure.Persistence.Scaffolded;

public partial class PlaySessionParticipant
{
    public int PlaySessionId { get; set; }

    public int MemberId { get; set; }

    public int? Score { get; set; }

    public int? Placement { get; set; }

    public bool IsWinner { get; set; }

    public virtual Member Member { get; set; } = null!;

    public virtual PlaySession PlaySession { get; set; } = null!;
}

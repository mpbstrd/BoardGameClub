using System;
using System.Collections.Generic;

namespace BoardGameClub.Infrastructure.Persistence.Entities;

public partial class play_session_participant
{
    public int play_session_id { get; set; }

    public int member_id { get; set; }

    public int? score { get; set; }

    public int? placement { get; set; }

    public bool is_winner { get; set; }

    public virtual member member { get; set; } = null!;

    public virtual play_session play_session { get; set; } = null!;
}

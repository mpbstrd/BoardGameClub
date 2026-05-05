using System;
using System.Collections.Generic;

namespace BoardGameClub.Infrastructure.Persistence.Entities;

public partial class ownership
{
    public int member_id { get; set; }

    public int board_game_id { get; set; }

    public string? condition { get; set; }

    public DateOnly? acquired_date { get; set; }

    public string? notes { get; set; }

    public virtual board_game board_game { get; set; } = null!;

    public virtual member member { get; set; } = null!;
}

using System;
using System.Collections.Generic;

namespace BoardGameClub.Infrastructure.Persistence.Entities;

public partial class rating
{
    public int member_id { get; set; }

    public int board_game_id { get; set; }

    public decimal rating1 { get; set; }

    public string? review { get; set; }

    public DateTime rated_at { get; set; }

    public virtual board_game board_game { get; set; } = null!;

    public virtual member member { get; set; } = null!;
}

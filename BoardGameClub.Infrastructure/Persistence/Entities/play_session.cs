using System;
using System.Collections.Generic;

namespace BoardGameClub.Infrastructure.Persistence.Entities;

public partial class play_session
{
    public int id { get; set; }

    public Guid public_id { get; set; }

    public int board_game_id { get; set; }

    public int? location_id { get; set; }

    public DateTime play_date { get; set; }

    public string? notes { get; set; }

    public DateTime created_at { get; set; }

    public virtual board_game board_game { get; set; } = null!;

    public virtual location? location { get; set; }

    public virtual ICollection<play_session_participant> play_session_participants { get; set; } = new List<play_session_participant>();
}

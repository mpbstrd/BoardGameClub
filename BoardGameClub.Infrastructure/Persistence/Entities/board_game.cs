using System;
using System.Collections.Generic;

namespace BoardGameClub.Infrastructure.Persistence.Entities;

public partial class board_game
{
    public int id { get; set; }

    public Guid public_id { get; set; }

    public string name { get; set; } = null!;

    public decimal? weight { get; set; }

    public int min_players { get; set; }

    public int max_players { get; set; }

    public int? duration { get; set; }

    public int? bgg_id { get; set; }

    public DateTime created_at { get; set; }

    public virtual ICollection<ownership> ownerships { get; set; } = new List<ownership>();

    public virtual ICollection<play_session> play_sessions { get; set; } = new List<play_session>();

    public virtual ICollection<rating> ratings { get; set; } = new List<rating>();

    public virtual ICollection<mechanism> mechanisms { get; set; } = new List<mechanism>();
}

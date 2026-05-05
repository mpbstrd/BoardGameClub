using System;
using System.Collections.Generic;

namespace BoardGameClub.Infrastructure.Persistence.Entities;

public partial class location
{
    public int id { get; set; }

    public string name { get; set; } = null!;

    public string? address { get; set; }

    public string? notes { get; set; }

    public virtual ICollection<play_session> play_sessions { get; set; } = new List<play_session>();
}

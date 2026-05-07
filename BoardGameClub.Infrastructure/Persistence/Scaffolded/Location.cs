using System;
using System.Collections.Generic;

namespace BoardGameClub.Infrastructure.Persistence.Scaffolded;

public partial class Location
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string? Address { get; set; }

    public string? Notes { get; set; }

    public virtual ICollection<PlaySession> PlaySessions { get; set; } = new List<PlaySession>();
}

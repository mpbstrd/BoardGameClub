using System;
using System.Collections.Generic;

namespace BoardGameClub.Infrastructure.Persistence.Scaffolded;

public partial class BoardGame
{
    public int Id { get; set; }

    public Guid PublicId { get; set; }

    public string Name { get; set; } = null!;

    public decimal? Weight { get; set; }

    public int MinPlayers { get; set; }

    public int MaxPlayers { get; set; }

    public int? Duration { get; set; }

    public int? BggId { get; set; }

    public DateTime CreatedAt { get; set; }

    public virtual ICollection<Ownership> Ownerships { get; set; } = new List<Ownership>();

    public virtual ICollection<PlaySession> PlaySessions { get; set; } = new List<PlaySession>();

    public virtual ICollection<Rating> Ratings { get; set; } = new List<Rating>();

    public virtual ICollection<Mechanism> Mechanisms { get; set; } = new List<Mechanism>();

    public virtual ICollection<Publisher> Publishers { get; set; } = new List<Publisher>();
}

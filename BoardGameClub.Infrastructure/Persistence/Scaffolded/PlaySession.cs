using System;
using System.Collections.Generic;

namespace BoardGameClub.Infrastructure.Persistence.Scaffolded;

public partial class PlaySession
{
    public int Id { get; set; }

    public Guid PublicId { get; set; }

    public int BoardGameId { get; set; }

    public int? LocationId { get; set; }

    public DateTime PlayDate { get; set; }

    public string? Notes { get; set; }

    public DateTime CreatedAt { get; set; }

    public virtual BoardGame BoardGame { get; set; } = null!;

    public virtual Location? Location { get; set; }

    public virtual ICollection<PlaySessionParticipant> PlaySessionParticipants { get; set; } = new List<PlaySessionParticipant>();
}

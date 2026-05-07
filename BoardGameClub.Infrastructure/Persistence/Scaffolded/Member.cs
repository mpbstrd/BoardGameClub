using System;
using System.Collections.Generic;

namespace BoardGameClub.Infrastructure.Persistence.Scaffolded;

public partial class Member
{
    public int Id { get; set; }

    public Guid PublicId { get; set; }

    public string Name { get; set; } = null!;

    public string Status { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual ICollection<Ownership> Ownerships { get; set; } = new List<Ownership>();

    public virtual ICollection<PlaySessionParticipant> PlaySessionParticipants { get; set; } = new List<PlaySessionParticipant>();

    public virtual ICollection<Rating> Ratings { get; set; } = new List<Rating>();
}

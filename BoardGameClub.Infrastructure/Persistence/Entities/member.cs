using System;
using System.Collections.Generic;

namespace BoardGameClub.Infrastructure.Persistence.Entities;

public partial class member
{
    public int id { get; set; }

    public Guid public_id { get; set; }

    public string name { get; set; } = null!;

    public string status { get; set; } = null!;

    public DateTime created_at { get; set; }

    public DateTime? updated_at { get; set; }

    public virtual ICollection<ownership> ownerships { get; set; } = new List<ownership>();

    public virtual ICollection<play_session_participant> play_session_participants { get; set; } = new List<play_session_participant>();

    public virtual ICollection<rating> ratings { get; set; } = new List<rating>();
}

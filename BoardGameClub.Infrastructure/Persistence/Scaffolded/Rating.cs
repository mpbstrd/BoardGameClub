using System;
using System.Collections.Generic;

namespace BoardGameClub.Infrastructure.Persistence.Scaffolded;

public partial class Rating
{
    public int MemberId { get; set; }

    public int BoardGameId { get; set; }

    public decimal Rating1 { get; set; }

    public string? Review { get; set; }

    public DateTime RatedAt { get; set; }

    public virtual BoardGame BoardGame { get; set; } = null!;

    public virtual Member Member { get; set; } = null!;
}

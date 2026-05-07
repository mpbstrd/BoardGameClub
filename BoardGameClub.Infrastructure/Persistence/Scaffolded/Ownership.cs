using System;
using System.Collections.Generic;

namespace BoardGameClub.Infrastructure.Persistence.Scaffolded;

public partial class Ownership
{
    public int MemberId { get; set; }

    public int BoardGameId { get; set; }

    public string? Condition { get; set; }

    public DateOnly? AcquiredDate { get; set; }

    public string? Notes { get; set; }

    public virtual BoardGame BoardGame { get; set; } = null!;

    public virtual Member Member { get; set; } = null!;
}

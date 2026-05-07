using System;
using System.Collections.Generic;

namespace BoardGameClub.Infrastructure.Persistence.Scaffolded;

public partial class Mechanism
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public virtual ICollection<BoardGame> BoardGames { get; set; } = new List<BoardGame>();
}

using System;
using System.Collections.Generic;

namespace BoardGameClub.Infrastructure.Persistence.Scaffolded;

public partial class Mechanic
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<BoardGame> BoardGames { get; set; } = new List<BoardGame>();
}

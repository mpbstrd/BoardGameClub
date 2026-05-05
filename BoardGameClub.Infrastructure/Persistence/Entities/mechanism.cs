using System;
using System.Collections.Generic;

namespace BoardGameClub.Infrastructure.Persistence.Entities;

public partial class mechanism
{
    public int id { get; set; }

    public string name { get; set; } = null!;

    public string? description { get; set; }

    public virtual ICollection<board_game> board_games { get; set; } = new List<board_game>();
}

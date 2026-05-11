using System;
using System.Collections.Generic;
using System.Text;

namespace BoardGameClub.Application.DTOs
{
    public class BggGameDto
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public int? YearPublished { get; set; }

        public string Description { get; set; } = string.Empty;

        public int? MinPlayers { get; set; }

        public int? MaxPlayers { get; set; }
        public int? PlayingTime { get; set; }
        public int? MinPlayTime { get; set; }
        public int? MaxPlayTime { get; set; }
        public List<CategoryDto>? Category { get; set; }
        public List<MechanicsDto>? Mechanics { get; set; }
    }
}

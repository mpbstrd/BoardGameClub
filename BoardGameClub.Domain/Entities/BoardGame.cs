using System;
using System.Collections.Generic;
using System.Text;

namespace BoardGameClub.Domain.Entities
{
    public class BoardGame
    {
        public int Id { get; set; }
        public Guid PublicId { get; set; }
        public required string Name { get; set; }
        public required float Weight { get; set; }
        public int MinimumPlayers { get; set; }
        public int MaximumPlayers { get; set; }
        public int MinimumDuration { get; set; }
        public int MaximumDuration { get; set; }
        public int BggId { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}

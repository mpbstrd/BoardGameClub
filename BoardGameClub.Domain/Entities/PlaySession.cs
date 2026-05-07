using System;
using System.Collections.Generic;
using System.Text;

namespace BoardGameClub.Domain.Entities
{
    public class PlaySession
    {
        public int Id { get; set; }
        public Guid PublicId { get; set; }
        public Guid BoardGameId { get; set; }
        public Guid LocationId { get; set; }
        public DateTime PlayedAt { get; set; }
        public string? Notes { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}

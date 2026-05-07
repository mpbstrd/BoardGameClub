using System;
using System.Collections.Generic;
using System.Text;

namespace BoardGameClub.Domain.Entities
{
    public class Location
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string? Address { get; set; }
        public string? Notes { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}

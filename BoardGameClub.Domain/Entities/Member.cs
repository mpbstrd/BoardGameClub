using System;
using System.Collections.Generic;
using System.Text;

namespace BoardGameClub.Domain.Entities
{
    public class Member
    {
        public int Id { get; set; }
        public Guid PublicId { get; set; }
        public required string Name { get; set; }
        public bool Status { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}

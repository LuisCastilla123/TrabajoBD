using System;
namespace CbMaker.Domain

{
    public class Skill
    {
        public long SkillId { get; set; }
        public Guid ExternalId { get; set; }
        public required string Description { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}

          
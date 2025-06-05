using System;
using System.Collections.Generic;

namespace CbMaker.Domain
{
    public class Skill
    {
        public long SkillId { get; set; }
        public Guid ExternalId { get; set; }
        public  string Description { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public ICollection<UserSkill> UserSkills { get; set; } = new List<UserSkill>();

        public Skill(string description)
        {
            Description = description;
            CreatedAt = DateTime.UtcNow;
            ExternalId = Guid.NewGuid();
        }

        public static Skill Create(string description)
        {
            return new Skill(description);
        }
    }
}



          
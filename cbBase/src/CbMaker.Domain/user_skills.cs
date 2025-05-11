using System;
namespace CbMaker.Domain

{
    public class UserSkill
    {
        public long UserSkillId { get; set; }
        public long UserId { get; set; }
        public long SkillId { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}


    
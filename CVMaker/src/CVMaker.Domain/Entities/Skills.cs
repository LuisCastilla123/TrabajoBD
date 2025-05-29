namespace CVMaker.Domain.Entities
{
    public class Skills
    {
        public Skills() { }

        public Skills(string description)
        {
            Description = description;
            CreatedAt = DateTime.UtcNow;
            ExternalId = Guid.NewGuid();
        }
        public static Skills Create(string description)
        {
            return new Skills(description);
        }
        public long SkillId { get; set; }
        public Guid ExternalId { get; set; }
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
       public  ICollection<UsersSkills>? UserSkills {get; set;} = new List<UsersSkills>();
    }
}
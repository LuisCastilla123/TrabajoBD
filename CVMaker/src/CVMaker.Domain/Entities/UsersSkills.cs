using CVMaker.Domain.Entities;

public class UsersSkills
{
    public long UserSkillId { get; set; }
    public long UserId { get; set; }
    public long SkillId { get; set; }
    public Guid ExternalID { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }

    public User User { get; set; }  // ✅ relación correcta
    public Skills Skill { get; set; }
}

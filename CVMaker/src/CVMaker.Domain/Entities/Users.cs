
namespace CVMaker.Domain.Entities
{
    public class User
    {
        public long UserId { get; set; }
        public Guid ExternalId { get; set; }
        public string Username { get; set; }
        public string Tag { get; set; }
        public string Email { get; set; }
        public bool EmailConfirmed { get; set; }
        public string PhoneNumber { get; set; }
        public bool PhoneNumberConfirmed { get; set; }
        public bool TwoFactorEnabled { get; set; }
        public string HashedPassword { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public DateTime DeletedAt { get; set; }
      public  ICollection<AcademicHistory>? AcademicHistory { get; set; } = new List<AcademicHistory>();
      public  ICollection<WorkExperiences>? WorkExperience {get; set;} = new List<WorkExperiences>();
     public   ICollection<UsersInfo>? UserInfo {get; set;} = new List<UsersInfo>();
        public UsersSkills UserSkills {get; set;}
    }
}

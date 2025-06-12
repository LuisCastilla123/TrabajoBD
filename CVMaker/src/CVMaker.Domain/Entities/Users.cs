
using System.Security.Cryptography.X509Certificates;

namespace CVMaker.Domain.Entities
{
    public class User
    {
        public User() { }

        // Constructor principal
        public User(string userName, string email, string phoneNumber, byte[] hashPassword, byte[] hashSalting, string location, string? about)
        {
            Username = userName;
            Email = email;
            PhoneNumber = phoneNumber;
            HashPassword = hashPassword;
            Tag = GenerateTag();
            HashSalting = hashSalting;
            CreatedAt = DateTime.UtcNow;
            ExternalId = Guid.NewGuid();
            AddInfo(location, about);
        }

        
        // Método de fábrica
        public User AddInfo(string location, string about = null)
        {
            var userInfo = Entities.UsersInfo.Create(UserId, location, about);
            UserInfo.Add(userInfo);
            return this;
        }

        public static User Create(string userName, string email, string phoneNumber, byte[] hashPassword, byte[] hashSalting, string location, string about = null)
        {
            return new User(userName, email, phoneNumber, hashPassword, hashSalting, location, about);
        }

        // Método personalizado (simulado según tu mención "Tag GenerateLog")


        public long UserId { get; set; }
        public Guid ExternalId { get; set; }
        public string Username { get; set; }
        public string Tag { get; set; }
        public string Email { get; set; }
        public bool EmailConfirmed { get; set; }
        public string PhoneNumber { get; set; }
        public bool PhoneNumberConfirmed { get; set; }
        public bool TwoFactorEnabled { get; set; }
        public byte[] HashPassword { get; set; }
        public byte[] HashSalting { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public DateTime DeletedAt { get; set; }
        public ICollection<AcademicHistory>? AcademicHistory { get; set; } = new List<AcademicHistory>();
        public ICollection<WorkExperiences>? WorkExperience { get; set; } = new List<WorkExperiences>();
        public ICollection<UsersInfo>? UserInfo { get; set; } = new List<UsersInfo>();
        public ICollection<UsersSkills>? UsersSkills { get; set; } = new List<UsersSkills>();

        private string GenerateTag()
        {
            var initials = string.Concat(Username.Split(' ', StringSplitOptions.RemoveEmptyEntries)
            .Select(word => word[0]))
            .ToUpper();
            var guidSuffix = ExternalId.ToString().Split('-').Last();
            return $"{initials}{guidSuffix}";
        }

        public void AddSkill(long SkillId)
        {
            UsersSkills.Add(new UsersSkills
            {
                SkillId = SkillId,
                UserId = UserId
            });
        }
    }

}

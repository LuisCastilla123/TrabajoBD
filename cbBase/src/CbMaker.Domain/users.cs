using System;
using System.Collections.Generic;
using System.Linq;

namespace CbMaker.Domain
{
    public class User
    {
        public long UserId { get; set; }
        public Guid ExternalId { get; set; } = Guid.NewGuid();
        public string Username { get; set; }
        public string Tag { get; set; }
        public string Email { get; set; }
        public bool EmailConfirmed { get; set; }
        public string PhoneNumber { get; set; }
        public bool PhoneNumberConfirmed { get; set; }
        public bool TwoFactorEnabled { get; set; }
        public string HashPassword { get; set; }
        public byte[] HashSalting { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? DeletedAt { get; set; }

        public ICollection<AcademicHistory> AcademicHistories { get; set; } = new List<AcademicHistory>();
        public ICollection<WorkExperience> WorkExperiences { get; set; } = new List<WorkExperience>();
        public UserInfo UserInfo { get; set; }
        public ICollection<UserSkill> UserSkills { get; set; } = new List<UserSkill>();
        public ICollection<UserInfoLanguage> UserInfoLanguages { get; set; } = new List<UserInfoLanguage>();

public static User Create(string username, string email, string phoneNumber, string hashPassword, byte[] hashSalting)
{
    var user = new User
    {
        Username = username,
        Email = email,
        PhoneNumber = phoneNumber,
        HashPassword = hashPassword,
        HashSalting = hashSalting, 
        CreatedAt = DateTime.UtcNow,
        UpdatedAt = DateTime.UtcNow,
        ExternalId = Guid.NewGuid()
    };

    user.Tag = user.GenerateTag();
    return user;
}



        private string GenerateTag()
        {
            var initials = string.Concat(Username
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(w => char.ToUpperInvariant(w[0])));

            var suffix = ExternalId.ToString().Split('-').Last();
            return $"{initials}{suffix}";
        }
    }
}
     
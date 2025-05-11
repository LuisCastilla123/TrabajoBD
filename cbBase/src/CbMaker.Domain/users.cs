using System;
namespace CbMaker.Domain
{
    public class User
    {
        public long UserId { get; set; }
        public Guid ExternalId { get; set; }
        public string Username { get; set; }
        public string Tag { get; set; }
        public string Email { get; set; }
        public string EmailConfirmed { get; set; } 
        public double PhoneNumber { get; set; } 
        public double PhoneNumberConfirmed { get; set; } 
        public bool TwoFactorEnabled { get; set; }
        public string HashPassword { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; } 

         public ICollection<AcademicHistory> AcademicHistories { get; set; }        
    }
}

        
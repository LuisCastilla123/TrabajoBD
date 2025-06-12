using System;

namespace CVMaker.Domain.Entities
{
    public class UsersInfo
    {

        public UsersInfo(){}
        public UsersInfo(long userId, string location, string? about)
        {
            UserId = UserId;
            Location = location;
            About = about;
            CreatedAt = DateTime.UtcNow;
        }

        public static UsersInfo Create(long userId, string location, string? about)
        {
            return new UsersInfo(userId, location, about);
        }
        public long UserInfoId { get; set; }
        public Guid ExternalId { get; set; }
        public string AddressOne { get; set; }
        public string AddressTwo { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Location { get; set; }
        public string About { get; set; }
        public string ZipCode { get; set; }
        public bool IsOver18 { get; set; }
        public bool IsCitizen { get; set; }
        public long UserId { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public User Users {get; set;}
        public ICollection<UsersInfoLanguages>? UserInfoLanguage {get; set;} = new List<UsersInfoLanguages>();
       
    }
}
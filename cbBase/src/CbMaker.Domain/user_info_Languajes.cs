using System;

namespace CbMaker.Domain
{
    public class UserInfoLanguage
    {
        public Guid ExternalId { get; set; }
        public double Level { get; set; }
        public long UserInfoId { get; set; }
        public Guid LanguageId { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public UserInfo UserInfo { get; set; }
        public Language Language { get; set; }
    }
}


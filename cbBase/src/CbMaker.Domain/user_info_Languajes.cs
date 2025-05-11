using System;
namespace CbMaker.Domain

{
    public class UserInfoLanguage
    {
        public Guid ExternalId { get; set; }
        public double Level { get; set; }
        public string UserInfoId { get; set; }     
        public DateTime CreatedAt { get; set; }   
        public string LanguageId { get; set; }     
        public DateTime UpdatedAt { get; set; }
    }
}

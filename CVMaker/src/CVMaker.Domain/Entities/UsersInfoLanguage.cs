namespace CVMaker.Domain.Entities
{
    public class UsersInfoLanguages
    {
        public long UserInfoLanguageId { get; set; }
        public Guid ExternalId { get; set; }
        public string Level { get; set; }
        public long UserInfoId { get; set; }
        public long LanguageId { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public UsersInfo UserInfo {get; set;}
        public Language Languages {get; set;}
    }
}
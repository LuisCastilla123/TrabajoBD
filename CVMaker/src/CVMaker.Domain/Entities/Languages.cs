namespace CVMaker.Domain.Entities
{
    public class Language
{
    public long languageId { get; set; }
    public Guid ExternalId { get; set; }
    public string description { get; set; }
    public DateTime createdAt { get; set; }
    public DateTime updatedAt { get; set; }
    public ICollection<UsersInfoLanguages>? UserInfoLanguage{get; set;} = new List<UsersInfoLanguages>();
}

}
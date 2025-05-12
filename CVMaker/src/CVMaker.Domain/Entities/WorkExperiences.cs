namespace CVMaker.Domain.Entities
{
    public class WorkExperiences
    {
        public long WorkExperienceId { get; set; }
        public Guid ExternalId { get; set; } = Guid.NewGuid();
        public string EnterpriseName { get; set; }
        public string Responsibilities { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public long JobTitleId { get; set; }
        public long UserId { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public User Users{get; set;}
        public JobTitles JobTitle{get; set;}
    }
}
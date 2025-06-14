namespace CVMaker.Domain.Entities
{
    public class WorkExperiences
    {
        private long? jobTitleId;

        public WorkExperiences(){}
        public WorkExperiences(string enterpriseName, DateTime startDate, DateTime? endDate, string? description, long? jobTitleId, long userId)
        {
            ExternalId = Guid.NewGuid();
            EnterpriseName = enterpriseName;
            StartDate = startDate;
            EndDate = (DateTime)endDate;
            Description = description;
            CreatedAt = DateTime.UtcNow;
            JobTitleId = (long)jobTitleId;
            UserId = userId;
        }

        public WorkExperiences(string enterpriseName, DateTime startDate,DateTime endDate, string? description, long? jobTitleId, long userId)
        {
            EnterpriseName = enterpriseName;
            StartDate = startDate;
            Description = description;
            this.jobTitleId = jobTitleId;
            UserId = userId;
            EndDate = endDate;
        }

        public static WorkExperiences Create(string enterpriseName, DateTime startDate, DateTime? endDate, string? description, long? jobTitleId, long userId)
        {
            return new WorkExperiences(enterpriseName, startDate,endDate, description, jobTitleId, userId);
        }
        public long WorkExperienceId { get; set; }
        public Guid ExternalId { get; set; } = Guid.NewGuid();
        public string EnterpriseName { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public long? JobTitleId { get; set; }
        public long UserId { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public User Users{get; set;}
        public JobTitles JobTitle{get; set;}
    }
}
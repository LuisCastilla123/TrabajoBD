namespace CVMaker.Domain.Entities
{
    public class JobTitles
    {
        public JobTitles() { }

        public JobTitles(string description)
        {
            Description = description;
            CreatedAt = DateTime.UtcNow;
            ExternalId = Guid.NewGuid();
        }
        public static JobTitles Create(string description)
        {
            return new JobTitles(description);
        }
        public long JobTitleId { get; set; }
        public Guid ExternalId { get; set; }
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public ICollection<WorkExperiences>? WorkExperience { get; set; } = new List<WorkExperiences>();
    }
}
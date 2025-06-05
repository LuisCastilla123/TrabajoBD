using System;

namespace CbMaker.Domain
{
    public class JobTitle
    {
        public long JobTitleId { get; set; }
        public Guid ExternalId { get; set; }
        public string Description { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public ICollection<WorkExperience> WorkExperiences { get; set; }

        public JobTitle() { }

        public JobTitle(string description)
        {
            Description = description;
            CreatedAt = DateTime.UtcNow;
            ExternalId = Guid.NewGuid();
        }

        public static JobTitle Create(string description)
        {
            return new JobTitle(description);
        }
    }
}

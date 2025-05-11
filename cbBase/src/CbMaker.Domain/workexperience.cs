using System;
namespace CbMaker.Domain

{
    public class WorkExperience
    {
        public long WorkExperienceId { get; set; }
        public Guid ExternalId { get; set; }
        public string EnterpriseName { get; set; }
        public string Responsibilities { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public long JobTitleId { get; set; }
        public long UserId { get; set; } 
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}

       
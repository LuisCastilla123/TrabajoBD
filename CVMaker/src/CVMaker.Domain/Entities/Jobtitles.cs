namespace CVMaker.Domain.Entities
{
    public class JobTitles
    {
        public long JobTitleId { get; set; }
        public Guid ExternalId { get; set; }
        public string Description  { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public ICollection<WorkExperiences>? WorkExperience{get; set;} = new List<WorkExperiences>();
    }
}
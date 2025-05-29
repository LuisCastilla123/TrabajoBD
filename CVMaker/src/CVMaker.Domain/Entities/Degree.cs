namespace CVMaker.Domain.Entities
{
    public class Degrees
    {
        public Degrees(){}
        public Degrees(string description)
        {
            Description = description;
            CreatedAt = DateTime.UtcNow;
            ExternalId = Guid.NewGuid();
        }
        public static Degrees Create(String description)
        {
            return new Degrees(description);
        }
        public long DegreeId { get; set; }
        public Guid ExternalId { get; set; }
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public ICollection<AcademicHistory>? AcademicHistorys {get; set;} = new List<AcademicHistory>();
    }
}   
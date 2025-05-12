namespace CVMaker.Domain.Entities
{
    public class Degrees
    {
        public long DegreeId { get; set; }
        public Guid ExternalId { get; set; }
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public ICollection<AcademicHistory>? AcademicHistorys {get; set;} = new List<AcademicHistory>();
    }
}
using System;
namespace CbMaker.Domain

{
    public class Degree
    {
        public long DegreeId { get; set; }
        public Guid ExternalId { get; set; }
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

          public ICollection<AcademicHistory> AcademicHistories { get; set; }
    }
}



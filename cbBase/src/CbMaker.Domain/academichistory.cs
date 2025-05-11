
using System;
namespace CbMaker.Domain
{
    public class AcademicHistory
    {
        public Guid ExternalId { get; set; }
        public string InstitutionName { get; set; }
        public string Speciality { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public long DegreeId { get; set; }
        public long AcademicFieldId { get; set; } 
        public long UserId { get; set; }       
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

         public AcademicField AcademicField { get; set; }
    public Degree Degree { get; set; }
    public User User { get; set; } 
    }
}

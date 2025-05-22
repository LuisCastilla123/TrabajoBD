namespace CVMaker.Domain.Entities
{

    public class AcademicHistory
    {

        public long AcademicHistoryID {get; set; }
        public Guid ExternalID {get; set; }
        public string InstitutionName {get; set; }
        public string Speciality {get; set;}
        public DateTime StartDate {get; set; }
        public DateTime? EndDate {get; set; }
        public long DegreeId {get; set; }
        public long AcademicFieldId {get; set; }
        public long UserId {get; set;}
        public DateTime CreatedAt {get; set;}
        public DateTime? UpdatedAt {get; set;}
        public AcademicField academicField {get; set;}
        public Degrees Degree {get; set;}
        public User Users {get; set;}
    }
}
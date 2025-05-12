namespace CVMaker.Domain.Entities
{

    public class AcademicFields
    {

        public long AcademicFieldsID {get; set; }
        public Guid ExternalID {get; set; }
        public string? Description {get; set; }
        public DateTime CreatedAt {get; set; }
        public DateTime? UpdatedAt {get; set; }
        public ICollection<AcademicHistory>? AcademicHistories {get; set;} = new List<AcademicHistory>();
    }
}
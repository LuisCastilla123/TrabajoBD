namespace CVMaker.Domain.Entities
{

    public class AcademicField
    {
        public AcademicField(string description)
        {
            Description = description;
            CreatedAt = DateTime.UtcNow;
            ExternalID = Guid.NewGuid();
    }
        public static AcademicField Create(string description)
        {
            return new AcademicField(description);
    }
    
    public AcademicField(){}

        public long AcademicFieldsID { get; set; }
        public Guid ExternalID {get; set; }
            public string? Description {get; set; }
        public DateTime CreatedAt {get; set; }
        public DateTime? UpdatedAt {get; set; }
        public ICollection<AcademicHistory>? AcademicHistories {get; set;} = new List<AcademicHistory>();
    }
}
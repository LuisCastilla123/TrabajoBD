using System;
namespace CbMaker.Domain

{
    public class Language
    {
        public long AcademicFieldId { get; set; }
        public Guid ExternalId { get; set; }
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}

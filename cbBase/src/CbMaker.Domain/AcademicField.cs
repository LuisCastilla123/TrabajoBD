using System;
using System.Collections.Generic;

namespace CbMaker.Domain
{
    public class AcademicField
    {
        public long AcademicFieldId { get; set; }
        public Guid ExternalId { get; set; }
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public ICollection<AcademicHistory> AcademicHistories { get; set; }

      
        private AcademicField(string description)
        {
            Description = description;
            CreatedAt = DateTime.UtcNow;
            ExternalId = Guid.NewGuid();
        }

        public static AcademicField Create(string description)
        {
            return new AcademicField(description);
        }

        public AcademicField() { }
    }
}

using System;
using System.Collections.Generic;

namespace CbMaker.Domain
{
    public class Language
    {
        public Guid ExternalId { get; set; }
        public Guid LanguageId { get; set; }
        public string Description { get; set; }
        public long AcademicFieldId { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public AcademicField AcademicField { get; set; }
        public ICollection<UserInfoLanguage> UserInfoLanguages { get; set; }
    }
}


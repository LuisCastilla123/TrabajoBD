using System;
using System.Collections.Generic;

namespace CbMaker.Domain
{
    public class Degree
    {
        public long DegreeId { get; set; }  // EF Core necesita setter para HasData
        public Guid ExternalId { get; set; }  // EF Core necesita setter
        public string Description { get; set; }  // setter público para HasData
        public DateTime CreatedAt { get; set; }  // setter público para HasData
        public DateTime UpdatedAt { get; set; }

        public ICollection<AcademicHistory> AcademicHistories { get; set; }

        // Constructor público sin parámetros para EF Core
        public Degree()
        {
            AcademicHistories = new List<AcademicHistory>();
        }

        // Puedes seguir teniendo este método para crear de forma controlada
        public static Degree Create(string description)
        {
            if (string.IsNullOrWhiteSpace(description))
                throw new ArgumentException("La descripción no puede estar vacía.", nameof(description));

            return new Degree
            {
                ExternalId = Guid.NewGuid(),
                Description = description,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,
                AcademicHistories = new List<AcademicHistory>()
            };
        }

        public void UpdateDescription(string newDescription)
        {
            if (string.IsNullOrWhiteSpace(newDescription))
                throw new ArgumentException("La descripción no puede estar vacía.", nameof(newDescription));

            Description = newDescription;
            UpdatedAt = DateTime.UtcNow;
        }
    }
}




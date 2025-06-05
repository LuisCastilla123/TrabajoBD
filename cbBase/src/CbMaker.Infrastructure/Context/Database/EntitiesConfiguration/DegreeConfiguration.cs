using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using CbMaker.Domain;
using System;

namespace CbMaker.Infrastructure.Context.EntitiesConfiguration
{
    internal sealed class DegreeConfiguration : IEntityTypeConfiguration<Degree>
    {
        public void Configure(EntityTypeBuilder<Degree> builder)
        {
            builder.ToTable("tb_degrees");

            builder.HasKey(e => e.DegreeId)
                   .HasName("degrees_pkey");

            builder.HasIndex(e => e.ExternalId)
                   .IsUnique()
                   .HasDatabaseName("degrees_externalid_key");

            builder.Property(e => e.DegreeId)
                   .ValueGeneratedOnAdd()
                   .HasColumnName("degree_id");

            builder.Property(e => e.ExternalId)
                   .HasColumnName("external_id")
                   .HasDefaultValueSql("NEWID()");

            builder.Property(e => e.Description)
                   .HasMaxLength(300)
                   .IsRequired()
                   .HasColumnName("description");

            builder.Property(e => e.CreatedAt)
                   .HasColumnType("datetime2")
                   .HasColumnName("created_at");

            builder.Property(e => e.UpdatedAt)
                   .HasColumnType("datetime2")
                   .HasColumnName("updated_at");

            // Valores fijos para evitar errores con HasData
            builder.HasData(
                new Degree
                {
                    DegreeId = 1,
                    Description = "Primaria",
                    ExternalId = new Guid("11111111-1111-1111-1111-111111111111"),
                    CreatedAt = new DateTime(2023, 01, 01),
                    UpdatedAt = new DateTime(2023, 01, 01)
                },
                new Degree
                {
                    DegreeId = 2,
                    Description = "Secundaria",
                    ExternalId = new Guid("22222222-2222-2222-2222-222222222222"),
                    CreatedAt = new DateTime(2023, 01, 01),
                    UpdatedAt = new DateTime(2023, 01, 01)
                },
                new Degree
                {
                    DegreeId = 3,
                    Description = "Universidad",
                    ExternalId = new Guid("33333333-3333-3333-3333-333333333333"),
                    CreatedAt = new DateTime(2023, 01, 01),
                    UpdatedAt = new DateTime(2023, 01, 01)
                },
                new Degree
                {
                    DegreeId = 4,
                    Description = "Maestría",
                    ExternalId = new Guid("44444444-4444-4444-4444-444444444444"),
                    CreatedAt = new DateTime(2023, 01, 01),
                    UpdatedAt = new DateTime(2023, 01, 01)
                },
                new Degree
                {
                    DegreeId = 5,
                    Description = "Doctorado",
                    ExternalId = new Guid("55555555-5555-5555-5555-555555555555"),
                    CreatedAt = new DateTime(2023, 01, 01),
                    UpdatedAt = new DateTime(2023, 01, 01)
                }
            );
        }
    }
}


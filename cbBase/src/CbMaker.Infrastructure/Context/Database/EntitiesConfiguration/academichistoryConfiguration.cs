
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using CbMaker.Domain;
namespace CbMaker.Infrastructure.Context.EntitiesConfiguration
{
    internal sealed class AcademicHistoryConfiguration : IEntityTypeConfiguration<AcademicHistory>
    {
        public void Configure(EntityTypeBuilder<AcademicHistory> builder)
        {
            builder.ToTable("tb_academic_histories");

            builder.HasKey(e => e.ExternalId)
                   .HasName("academichistories_pkey");

            builder.HasIndex(e => e.ExternalId, "academichistories_externalid_key")
                   .IsUnique();

            builder.Property(e => e.ExternalId)
                   .HasDefaultValueSql("NEWID()")
                   .HasColumnName("external_id");

            builder.Property(e => e.InstitutionName)
                   .HasMaxLength(250)
                   .IsRequired()
                   .HasColumnName("institution_name");
            builder.Property(e => e.InstitutionName)
                   .HasMaxLength(250)
                   .IsRequired()
                   .HasColumnName("institution_name");

            builder.Property(e => e.Speciality)
                   .HasMaxLength(200)
                   .IsRequired()
                   .HasColumnName("speciality");

            builder.Property(e => e.StartDate)
                   .HasColumnType("datetime2")
                   .HasColumnName("start_date");

            builder.Property(e => e.EndDate)
                   .HasColumnType("datetime2")
                   .HasColumnName("end_date");

            builder.Property(e => e.DegreeId)
                   .HasMaxLength(100)
                   .IsRequired()
                   .HasColumnName("degree_id");

            builder.Property(e => e.AcademicFieldId)
                   .HasColumnName("academifield_id");

            builder.Property(e => e.UserId)
                   .HasColumnName("user_id");

            builder.Property(e => e.CreatedAt)
                   .HasColumnType("datetime2")
                   .HasColumnName("created_at");

            builder.Property(e => e.UpdatedAt)
                   .HasColumnType("datetime2")
                   .HasColumnName("updated_at");

                   builder.HasOne(d => d. AcademicField).WithMany (p => p.AcademicHistories);

                    builder.HasOne(e => e.AcademicField) // Relación de muchos a uno
               .WithMany(e => e.AcademicHistories)
               .HasForeignKey(e => e.AcademicFieldId);

        builder.HasOne(e => e.Degree) // Relación de muchos a uno
               .WithMany() // No se especifica la relación inversa, ya que no se necesita en este caso
               .HasForeignKey(e => e.DegreeId);

        builder.HasOne(e => e.User) // Relación de muchos a uno
               .WithMany() // No se especifica la relación inversa
               .HasForeignKey(e => e.UserId);
        }
    }
}

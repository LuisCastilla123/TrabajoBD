using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using CbMaker.Domain; 

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
                     .IsRequired()
                     .HasColumnName("degree_id");

              builder.Property(e => e.AcademicFieldId)
                     .HasColumnName("academic_field_id");

              builder.Property(e => e.UserId)
                     .HasColumnName("user_id");

              builder.Property(e => e.CreatedAt)
                     .HasColumnType("datetime2")
                     .HasColumnName("created_at");

              builder.Property(e => e.UpdatedAt)
                     .HasColumnType("datetime2")
                     .HasColumnName("updated_at");

              builder.HasOne(e => e.AcademicField)
                     .WithMany(e => e.AcademicHistories)
                     .HasForeignKey(e => e.AcademicFieldId);

              builder.HasOne(e => e.Degree)
                     .WithMany(d => d.AcademicHistories)
                     .HasForeignKey(e => e.DegreeId);

              builder.HasOne(e => e.User)
                     .WithMany(u => u.AcademicHistories)
                     .HasForeignKey(e => e.UserId);
       }
}


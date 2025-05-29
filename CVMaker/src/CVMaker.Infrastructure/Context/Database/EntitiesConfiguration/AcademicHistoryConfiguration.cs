using CVMaker.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CVMaker.Infrastructure.Context.EntitiesConfiguration
{
    internal sealed class AcademicHistoryConfiguration : IEntityTypeConfiguration<AcademicHistory>
    {
        public void Configure(EntityTypeBuilder<AcademicHistory> builder)
        {
            builder.HasKey(e => e.AcademicHistoryID).HasName("academic_history_pkey");
            builder.ToTable("tb_academic_history");
            builder.HasIndex(e => e.ExternalID, "academic_history_externalid_key").IsUnique();

            builder.Property(e => e.AcademicHistoryID)
                .ValueGeneratedOnAdd()
                .HasColumnName("academic_history_id");

            builder.Property(e => e.ExternalID)
                .HasDefaultValueSql("NEWID()")
                .HasColumnName("external_id");

            builder.Property(e => e.InstitutionName)
                .HasMaxLength(500)
                .HasColumnName("institutionname");

            builder.Property(e => e.Speciality)
                .HasMaxLength(500)
                .HasColumnName("specialty");

            builder.Property(e => e.StartDate)
                .HasColumnType("datetime2")
                .HasColumnName("startdate");

            builder.Property(e => e.EndDate)
                .HasColumnType("datetime2")
                .HasColumnName("enddate");

            builder.Property(e => e.DegreeId)
                .HasColumnName("degreeid");

            builder.Property(e => e.AcademicFieldId)
                .HasColumnName("academicfieldid");

            builder.Property(e => e.UserId)
                .HasColumnName("userid");

            builder.Property(e => e.CreatedAt)
                .HasColumnType("datetime2")
                .HasColumnName("createdat");

            builder.Property(e => e.UpdatedAt)
                .HasColumnType("datetime2")
                .HasColumnName("updatedat");

            builder.HasOne(e => e.academicField)
                .WithMany()
                .HasForeignKey(e => e.AcademicFieldId);

            builder.HasOne(e => e.Degree)
                .WithMany(d => d.AcademicHistorys)
                .HasForeignKey(e => e.DegreeId);

            builder
                .HasOne(e => e.Users)
                .WithMany()
                .HasForeignKey(e => e.UserId); 

            builder
                .HasOne(e => e.academicField)
                .WithMany(ah => ah.AcademicHistories)
                .HasForeignKey(ah => ah.AcademicFieldId)
                .OnDelete(DeleteBehavior.ClientSetNull);


            builder
                .HasOne(af => af.Degree)
                .WithMany(ah => ah.AcademicHistorys)
                .HasForeignKey(ah => ah.DegreeId)
                .OnDelete(DeleteBehavior.ClientSetNull);

             builder
                .HasOne(ah => ah.Users)
                .WithMany(ah => ah.AcademicHistory)
                .HasForeignKey(ah => ah.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull);   
        }
    }
}
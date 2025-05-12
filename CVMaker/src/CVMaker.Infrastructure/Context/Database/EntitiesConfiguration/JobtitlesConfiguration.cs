using CVMaker.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CVMaker.Infrastructure.Context.EntitiesConfiguration
{
    internal sealed class JobTitleConfiguration : IEntityTypeConfiguration<JobTitles>
    {
        public void Configure(EntityTypeBuilder<JobTitles> builder)
        {
            builder.HasKey(e => e.JobTitleId).HasName("job_titles_pkey");
            builder.ToTable("tb_job_titles");
            builder.HasIndex(e => e.ExternalId, "job_titles_externalid_key").IsUnique();

            builder.Property(e => e.JobTitleId)
                .ValueGeneratedOnAdd()
                .HasColumnName("jobtitleid");

            builder.Property(e => e.ExternalId)
                .HasDefaultValueSql("NEWID()")
                .HasColumnName("external_id");

            builder.Property(e => e.Description)
                .HasMaxLength(500)
                .HasColumnName("description");

            builder.Property(e => e.CreatedAt)
                .HasColumnType("DateTime")
                .HasColumnName("createdat");

            builder.Property(e => e.UpdatedAt)
                .HasColumnType("DateTime")
                .HasColumnName("updatedat");

            builder.HasMany(e => e.WorkExperience)
                .WithOne(e => e.JobTitle)
                .HasForeignKey(e => e.JobTitleId);

            builder
            .HasMany(af => af.WorkExperience)
            .WithOne(ah => ah.JobTitle)
            .HasForeignKey(ah => ah.JobTitleId)
            .OnDelete(DeleteBehavior.ClientSetNull);




        }
    }
}
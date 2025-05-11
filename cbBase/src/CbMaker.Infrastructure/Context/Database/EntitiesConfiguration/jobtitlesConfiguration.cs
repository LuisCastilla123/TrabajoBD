
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using CbMaker.Domain;
namespace CbMaker.Infrastructure.Context.EntitiesConfiguration
{
    internal sealed class JobTitleConfiguration : IEntityTypeConfiguration<JobTitle>
    {
        public void Configure(EntityTypeBuilder<JobTitle> builder)
        {
            builder.ToTable("tb_job_titles");

            builder.HasKey(e => e.JobTitleId)
                   .HasName("jobtitles_pkey");

            builder.HasIndex(e => e.ExternalId, "jobtitles_externalid_key")
                   .IsUnique();

            builder.Property(e => e.JobTitleId)
                   .ValueGeneratedOnAdd()
                   .HasColumnName("jobtitle_id");

            builder.Property(e => e.ExternalId)
                   .HasDefaultValueSql("NEWID()")
                   .HasColumnName("external_id");

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
        }
    }
}

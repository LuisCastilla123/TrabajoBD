
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using CbMaker.Domain;
namespace CbMaker.Infrastructure.Context.EntitiesConfiguration
{
    internal sealed class WorkExperienceConfiguration : IEntityTypeConfiguration<WorkExperience>
    {
        public void Configure(EntityTypeBuilder<WorkExperience> builder)
        {
            builder.ToTable("tb_work_experience");

            builder.HasKey(e => e.WorkExperienceId)
                   .HasName("workexperience_pkey");

            builder.HasIndex(e => e.ExternalId, "workexperience_externalid_key")
                   .IsUnique();

            builder.Property(e => e.WorkExperienceId)
                   .ValueGeneratedOnAdd()
                   .HasColumnName("work_experience_id");

            builder.Property(e => e.ExternalId)
                   .HasDefaultValueSql("NEWID()")
                   .HasColumnName("external_id");

            builder.Property(e => e.EnterpriseName)
                   .HasMaxLength(200)
                   .HasColumnName("enterprise_name");

            builder.Property(e => e.Responsibilities)
                   .HasMaxLength(1000)
                   .HasColumnName("responsibilities");

            builder.Property(e => e.StartDate)
                   .HasColumnType("datetime2")
                   .HasColumnName("start_date");

            builder.Property(e => e.EndDate)
                   .HasColumnType("datetime2")
                   .HasColumnName("end_date");

            builder.Property(e => e.JobTitleId)
                   .HasColumnName("job_title_id");

            builder.Property(e => e.UserId)
                   .HasColumnName("user_id");

            builder.Property(e => e.CreatedAt)
                   .HasColumnType("datetime2")
                   .HasColumnName("created_at");

            builder.Property(e => e.UpdatedAt)
                   .HasColumnType("datetime2")
                   .HasColumnName("updated_at");
        }
    }
}

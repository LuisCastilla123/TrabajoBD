using CVMaker.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace CVMaker. Infrastructure.Context.EntitiesConfiguration
{
    internal sealed class WorkExperienceConfiguration : IEntityTypeConfiguration<WorkExperiences>
    {
        public void Configure(EntityTypeBuilder<WorkExperiences> builder)
        {
            builder.HasKey(e => e.WorkExperienceId).HasName("workexperiences_pkey");
            builder.ToTable("workexperiences");
            builder.HasIndex(e => e.ExternalId, "workexperiences_externalid_key").IsUnique();
            builder.Property(e => e.WorkExperienceId)
                .ValueGeneratedOnAdd()
                .HasColumnName("workexperienceid");
            builder.Property(e => e.CreatedAt)
                .HasColumnType("DateTime")
                .HasColumnName("createdat");
            builder.Property(e => e.EnterpriseName).HasMaxLength(500)
                .HasColumnName("enterprisename");
            builder.Property(e => e.ExternalId)
                .HasDefaultValueSql("NEWID()")
                .HasColumnName("externalid");
            builder.Property(e => e.Responsibilities).HasMaxLength(500)
                .HasColumnName("responsibilities");
            builder.Property(e => e.StartDate)
                .HasColumnType("DateTime")
                .HasColumnName("startdate");
            builder.Property(e => e.EndDate)
                .HasColumnType("DateTime")
                .HasColumnName("enddate");
            builder.Property(e => e.JobTitleId)
                .HasColumnName("jobtitleid");
            builder.Property(e => e.UserId)
                .HasColumnName("userid");
     
            builder
            .HasOne(e => e.JobTitle)
            .WithMany(ah => ah.WorkExperience)
            .HasForeignKey(ah => ah.JobTitleId)
            .OnDelete(DeleteBehavior.ClientSetNull);

            builder
            .HasOne(af => af.Users)
            .WithMany(ah => ah.WorkExperience)
            .HasForeignKey(ah => ah.UserId)
            .OnDelete(DeleteBehavior.ClientSetNull);






        }
    }
}
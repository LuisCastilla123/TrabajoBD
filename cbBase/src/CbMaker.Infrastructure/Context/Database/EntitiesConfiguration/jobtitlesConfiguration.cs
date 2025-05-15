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

            builder.HasData(
                new JobTitle { JobTitleId = 1, Description = "Desarrollador de sistemas" },
                new JobTitle { JobTitleId = 2, Description = "Analista de compras" },
                new JobTitle { JobTitleId = 3, Description = "Gerente de mercado" },
                new JobTitle { JobTitleId = 4, Description = "Director de planta" },
                new JobTitle { JobTitleId = 5, Description = "Coordinador" },
                new JobTitle { JobTitleId = 6, Description = "Asistente personal" },
                new JobTitle { JobTitleId = 7, Description = "Consultor de sistemas" },
                new JobTitle { JobTitleId = 8, Description = "Arquitecto" },
                new JobTitle { JobTitleId = 9, Description = "Ingeniero eléctrico" }
            );
        }
    }
}



using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using CbMaker.Domain;
namespace CbMaker.Infrastructure.Context.EntitiesConfiguration
{
    internal sealed class LanguageConfiguration : IEntityTypeConfiguration<Language>
    {
        public void Configure(EntityTypeBuilder<Language> builder)
        {
            builder.ToTable("tb_languages");

            builder.HasKey(e => e.ExternalId)
                   .HasName("languages_pkey");

            builder.HasIndex(e => e.ExternalId, "languages_externalid_key")
                   .IsUnique();

            builder.Property(e => e.ExternalId)
                   .HasDefaultValueSql("NEWID()")
                   .HasColumnName("external_id");

            builder.Property(e => e.Description)
                   .HasMaxLength(200)
                   .IsRequired()
                   .HasColumnName("description");

          builder.Property(e => e.AcademicFieldId)
                   .HasColumnName("academifield_id");

            builder.Property(e => e.CreatedAt)
                   .HasColumnType("datetime2")
                   .HasColumnName("created_at");

            builder.Property(e => e.UpdatedAt)
                   .HasColumnType("datetime2")
                   .HasColumnName("updated_at");

                 

        }
    }
}

using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using CbMaker.Domain;

namespace CbMaker.Infrastructure.Context.EntitiesConfiguration
{
    internal sealed class AcademicFieldsConfiguration : IEntityTypeConfiguration<AcademicField>
    {
        public void Configure(EntityTypeBuilder<AcademicField> builder)
        {
            builder.HasKey(e => e.AcademicFieldId)
                   .HasName("academifields_pkey");

            builder.ToTable("tb_academifields");

            builder.HasIndex(e => e.ExternalId, "academifields_externalid_key")
                   .IsUnique();

            builder.Property(e => e.AcademicFieldId)
                   .ValueGeneratedOnAdd()
                   .HasColumnName("academifield_id");

            builder.Property(e => e.CreatedAt)
                   .HasColumnType("datetime2")
                   .HasColumnName("created_at");

            builder.Property(e => e.UpdatedAt)
                   .HasColumnType("datetime2")
                   .HasColumnName("updated_at");

            builder.Property(e => e.Description)
                   .HasMaxLength(500)
                   .HasColumnName("description");

            builder.Property(e => e.ExternalId)
                   .HasDefaultValueSql("NEWID()")
                   .HasColumnName("external_id");

                   
        builder.HasMany(e => e.AcademicHistories)
               .WithOne(e => e.AcademicField)
               .HasForeignKey(e => e.AcademicFieldId);
        }
    }
}

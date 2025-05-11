
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using  CbMaker.Domain;
namespace CbMaker.Infrastructure.Context.EntitiesConfiguration
{
    internal sealed class DegreeConfiguration : IEntityTypeConfiguration<Degree>
    {
        public void Configure(EntityTypeBuilder<Degree> builder)
        {
            builder.ToTable("tb_degrees");

            builder.HasKey(e => e.DegreeId)
                   .HasName("degrees_pkey");

            builder.HasIndex(e => e.ExternalId, "degrees_externalid_key")
                   .IsUnique();

            builder.Property(e => e.DegreeId)
                   .ValueGeneratedOnAdd()
                   .HasColumnName("degree_id");

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

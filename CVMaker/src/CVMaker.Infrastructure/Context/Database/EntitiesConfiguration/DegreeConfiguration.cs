using CVMaker.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CVMaker.Infrastructure.Context.EntitiesConfiguration
{
     internal sealed class DegreeConfiguration : IEntityTypeConfiguration<Degrees>
    {
        public void Configure(EntityTypeBuilder<Degrees> builder)
        {
            builder.HasKey(e => e.DegreeId).HasName("degrees_pkey");
            builder.ToTable("tb_degrees");
            builder.HasIndex(e => e.ExternalId, "degrees_externalid_key").IsUnique();

            builder.Property(e => e.DegreeId)
                .ValueGeneratedOnAdd()
                .HasColumnName("degreeid");

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

            builder.HasMany(e => e.AcademicHistorys)
                .WithOne(e => e.Degree)
                .HasForeignKey(e => e.DegreeId);

            builder
            .Property(e => e.CreatedAt)
            .HasColumnType("DateTime2")
            .HasColumnName("created_at");

            builder
            .HasMany(af => af.AcademicHistorys)
            .WithOne(ah => ah.Degree)
            .HasForeignKey(ah => ah.DegreeId)
            .OnDelete(DeleteBehavior.ClientSetNull);
            
                 

        }
    }
}
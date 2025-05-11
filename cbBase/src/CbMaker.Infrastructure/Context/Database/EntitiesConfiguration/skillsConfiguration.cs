using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using CbMaker.Domain;
namespace CbMaker.Infrastructure.Context.EntitiesConfiguration
{
    internal sealed class SkillConfiguration : IEntityTypeConfiguration<Skill>
    {
        public void Configure(EntityTypeBuilder<Skill> builder)
        {
            builder.ToTable("tb_skills");

            builder.HasKey(e => e.SkillId)
                   .HasName("skills_pkey");

            builder.HasIndex(e => e.ExternalId, "skills_externalid_key")
                   .IsUnique();

            builder.Property(e => e.SkillId)
                   .ValueGeneratedOnAdd()
                   .HasColumnName("skill_id");

            builder.Property(e => e.ExternalId)
                   .HasDefaultValueSql("NEWID()")
                   .HasColumnName("external_id");

            builder.Property(e => e.Description)
                   .HasMaxLength(200)
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


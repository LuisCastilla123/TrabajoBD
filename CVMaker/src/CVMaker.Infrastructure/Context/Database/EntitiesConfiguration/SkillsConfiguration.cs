using CVMaker.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CVMaker.Infrastructure.Context.EntitiesConfiguration
{internal sealed class SkillConfiguration : IEntityTypeConfiguration<Skills>
    {
        public void Configure(EntityTypeBuilder<Skills> builder)
        {
            builder.HasKey(e => e.SkillId).HasName("skills_pkey");
            builder.ToTable("tb_skills");
            builder.HasIndex(e => e.ExternalId, "skills_externalid_key").IsUnique();

            builder.Property(e => e.SkillId)
                .ValueGeneratedOnAdd()
                .HasColumnName("skillid");

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

            builder.HasMany(e => e.UserSkills)
                .WithOne(e => e.Skill)
                .HasForeignKey(e => e.SkillId);

            builder
            .HasMany(af => af.UserSkills)
            .WithOne(ah => ah.Skill)
            .HasForeignKey(ah => ah.SkillId)
            .OnDelete(DeleteBehavior.ClientSetNull);
        }
    }
}
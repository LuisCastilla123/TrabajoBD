using CVMaker.Domain.Entities;

// Ensure the namespace containing UserSkills is imported
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CVMaker.Infrastructure.Context.EntitiesConfiguration
{
    internal sealed class UserSkillsConfiguration : IEntityTypeConfiguration<UsersSkills>
    {
        public void Configure(EntityTypeBuilder<UsersSkills> builder)
        {
            builder.HasKey(e => e.UserSkillId).HasName("users_skills_pkey");
            builder.ToTable("tb_users_skills");
            builder.HasIndex(e => e.ExternalID, "users_skills_externalid_key").IsUnique();

            builder.Property(e => e.UserSkillId)
                .ValueGeneratedOnAdd()
                .HasColumnName("userskillid");

            builder.Property(e => e.ExternalID)
                .HasDefaultValueSql("NEWID()")
                .HasColumnName("external_id");

            builder.Property(e => e.UserId)
                .HasColumnName("userid");

            builder.Property(e => e.SkillId)
                .HasColumnName("skillid");

            builder.Property(e => e.CreatedAt)
                .HasColumnType("datetime2")
                .HasColumnName("createdat");

            builder.Property(e => e.UpdatedAt)
                .HasColumnType("datetime2")
                .HasColumnName("updatedat");

           


            builder
        .HasOne(af => af.Skill)
        .WithMany(ah => ah.UserSkills)
        .HasForeignKey(ah => ah.SkillId)
        .OnDelete(DeleteBehavior.ClientSetNull);
        
         builder
        .HasOne(af => af.User)
        .WithMany(ah => ah.UsersSkills)
        .HasForeignKey(ah => ah.UserId)
        .OnDelete(DeleteBehavior.ClientSetNull);
        
        }
    }
}
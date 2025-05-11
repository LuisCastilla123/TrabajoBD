
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using CbMaker.Domain;
namespace CbMaker.Infrastructure.Context.EntitiesConfiguration
{
    internal sealed class UserSkillConfiguration : IEntityTypeConfiguration<UserSkill>
    {
        public void Configure(EntityTypeBuilder<UserSkill> builder)
        {
            builder.ToTable("tb_user_skills");

            builder.HasKey(e => e.UserSkillId)
                   .HasName("userskills_pkey");

            builder.Property(e => e.UserSkillId)
                   .ValueGeneratedOnAdd()
                   .HasColumnName("user_skill_id");

            builder.Property(e => e.UserId)
                   .HasColumnName("user_id");

            builder.Property(e => e.SkillId)
                   .HasColumnName("skill_id");

            builder.Property(e => e.CreatedAt)
                   .HasColumnType("datetime2")
                   .HasColumnName("created_at");

            builder.Property(e => e.UpdatedAt)
                   .HasColumnType("datetime2")
                   .HasColumnName("updated_at");
      }
    }
}
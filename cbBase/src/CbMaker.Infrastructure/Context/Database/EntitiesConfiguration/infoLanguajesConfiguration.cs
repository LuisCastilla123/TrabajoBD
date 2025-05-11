
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using CbMaker.Domain;
namespace CbMaker.Infrastructure.Context.EntitiesConfiguration
{
    internal sealed class UserInfoLanguageConfiguration : IEntityTypeConfiguration<UserInfoLanguage>
    {
        public void Configure(EntityTypeBuilder<UserInfoLanguage> builder)
        {
            builder.ToTable("tb_user_info_languages");

            builder.HasKey(e => e.ExternalId)
                   .HasName("userinfolanguages_pkey");

            builder.HasIndex(e => e.ExternalId, "userinfolanguages_externalid_key")
                   .IsUnique();

            builder.Property(e => e.ExternalId)
                   .HasDefaultValueSql("NEWID()")
                   .HasColumnName("external_id");

            builder.Property(e => e.Level)
                   .HasColumnType("float")
                   .IsRequired()
                   .HasColumnName("level");

            builder.Property(e => e.UserInfoId)
                   .HasMaxLength(100)
                   .IsRequired()
                   .HasColumnName("user_info_id");

            builder.Property(e => e.LanguageId)
                   .HasMaxLength(100)
                   .IsRequired()
                   .HasColumnName("language_id");

            builder.Property(e => e.CreatedAt)
                   .HasColumnType("datetime2")
                   .HasColumnName("created_at");

            builder.Property(e => e.UpdatedAt)
                   .HasColumnType("datetime2")
                   .HasColumnName("updated_at");
        }
    }
}

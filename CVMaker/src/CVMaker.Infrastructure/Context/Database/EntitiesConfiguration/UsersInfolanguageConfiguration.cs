using CVMaker.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace CVMaker. Infrastructure.Context.EntitiesConfiguration
{
    internal sealed class UsersInfoLanguageConfiguration : IEntityTypeConfiguration<UsersInfoLanguages>
{
    public void Configure(EntityTypeBuilder<UsersInfoLanguages> builder)
    {
        builder.HasKey(e => e.UserInfoLanguageId).HasName("users_info_languages_pkey");
        builder.ToTable("tb_users_info_languages");
        builder.HasIndex(e => e.ExternalId, "users_info_languages_externalid_key").IsUnique();

        builder.Property(e => e.UserInfoLanguageId)
            .ValueGeneratedOnAdd()
            .HasColumnName("userinfo_language_id");

        builder.Property(e => e.ExternalId)
            .HasDefaultValueSql("NEWID()")
            .HasColumnName("external_id");

        builder.Property(e => e.Level)
            .HasMaxLength(250)
            .HasColumnName("level");

        builder.Property(e => e.UserInfoId)
            .HasColumnName("userinfoid");

        builder.Property(e => e.LanguageId)
            .HasColumnName("languageid");

        builder.Property(e => e.CreatedAt)
            .HasColumnType("datetime2")
            .HasColumnName("createdat");

        builder.Property(e => e.UpdatedAt)
            .HasColumnType("datetime2")
            .HasColumnName("updatedat");

        builder.HasOne(e => e.UserInfo)
            .WithMany(u => u.UserInfoLanguage)
            .HasForeignKey(e => e.UserInfoId);

        builder.HasOne(e => e.Languages)
            .WithMany(l => l.UserInfoLanguage)
            .HasForeignKey(e => e.LanguageId);

        builder
        .HasOne(af => af.Languages)
        .WithMany(ah => ah.UserInfoLanguage)
        .HasForeignKey(ah => ah.LanguageId)
        .OnDelete(DeleteBehavior.ClientSetNull);

        builder
        .HasOne(af => af.UserInfo)
        .WithMany(ah => ah.UserInfoLanguage)
        .HasForeignKey(ah => ah.UserInfoId)
        .OnDelete(DeleteBehavior.ClientSetNull);
    }
}
}
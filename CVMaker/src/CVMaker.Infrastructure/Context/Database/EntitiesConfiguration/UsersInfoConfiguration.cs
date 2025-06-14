using CVMaker.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CVMaker.Infrastructure.Context.EntitiesConfiguration
{
    internal sealed class UsersInfoConfiguration : IEntityTypeConfiguration<UsersInfo>
{
    public void Configure(EntityTypeBuilder<UsersInfo> builder)
    {
        builder.HasKey(e => e.UserInfoId).HasName("users_info_pkey");
        builder.ToTable("tb_users_info");
        builder.HasIndex(e => e.ExternalId, "users_info_externalid_key").IsUnique();

        builder.Property(e => e.UserInfoId)
            .ValueGeneratedOnAdd()
            .HasColumnName("userinfoid");

        builder.Property(e => e.ExternalId)
            .HasDefaultValueSql("NEWID()")
            .HasColumnName("external_id");

            builder.Property(e => e.Location)
            .HasMaxLength(500)
            .HasColumnName("location");

            builder.Property(e => e.About)
            .HasMaxLength(500)
            .HasColumnName("about");


        builder.Property(e => e.UserId)
            .HasColumnName("userid");

        builder.Property(e => e.CreatedAt)
            .HasColumnType("datetime2")
            .HasColumnName("createdat");

        builder.Property(e => e.UpdatedAt)
            .HasColumnType("datetime2")
            .HasColumnName("updatedat");

       

        builder
        .HasMany(af => af.UserInfoLanguage)
        .WithOne(ah => ah.UserInfo)
        .HasForeignKey(ah => ah.UserInfoId)
        .OnDelete(DeleteBehavior.ClientSetNull);

        builder
        .HasOne(af => af.Users)
        .WithMany(ah => ah.UserInfo)
        .HasForeignKey(ah => ah.UserId)
        .OnDelete(DeleteBehavior.ClientSetNull);
    }
  }
}
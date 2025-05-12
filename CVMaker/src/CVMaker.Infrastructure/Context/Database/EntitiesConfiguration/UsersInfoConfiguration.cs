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

        builder.Property(e => e.AddressOne)
            .HasMaxLength(500)
            .HasColumnName("addressone");

        builder.Property(e => e.AddressTwo)
            .HasMaxLength(500)
            .HasColumnName("addresstwo");

        builder.Property(e => e.City)
            .HasMaxLength(200)
            .HasColumnName("city");

        builder.Property(e => e.State)
            .HasMaxLength(200)
            .HasColumnName("state");

        builder.Property(e => e.ZipCode)
            .HasMaxLength(50)
            .HasColumnName("zipcode");

        builder.Property(e => e.IsOver18)
            .HasColumnName("isover18");

        builder.Property(e => e.IsCitizen)
            .HasColumnName("iscitizen");

        builder.Property(e => e.UserId)
            .HasColumnName("userid");

        builder.Property(e => e.CreatedAt)
            .HasColumnType("DateTime")
            .HasColumnName("createdat");

        builder.Property(e => e.UpdatedAt)
            .HasColumnType("DateTime")
            .HasColumnName("updatedat");

        builder.HasOne(e => e.Users)
            .WithMany(u => u.UserInfo)
            .HasForeignKey(e => e.UserId);

        builder.HasMany(e => e.UserInfoLanguage)
            .WithOne(e => e.UserInfo)
            .HasForeignKey(e => e.UserInfoId);

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
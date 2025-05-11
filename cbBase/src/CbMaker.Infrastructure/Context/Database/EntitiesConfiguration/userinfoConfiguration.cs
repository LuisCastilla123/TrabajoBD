
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using CbMaker.Domain;
namespace CbMaker.Infrastructure.Context.EntitiesConfiguration
{
    internal sealed class UserInfoConfiguration : IEntityTypeConfiguration<UserInfo>
    {
        public void Configure(EntityTypeBuilder<UserInfo> builder)
        {
            builder.ToTable("tb_user_info");

            builder.HasKey(e => e.UserInfoId)
                   .HasName("userinfo_pkey");

            builder.HasIndex(e => e.ExternalId, "userinfo_externalid_key")
                   .IsUnique();

            builder.Property(e => e.UserInfoId)
                   .ValueGeneratedOnAdd()
                   .HasColumnName("userinfo_id");

            builder.Property(e => e.ExternalId)
                   .HasDefaultValueSql("NEWID()")
                   .HasColumnName("external_id");

            builder.Property(e => e.AddressOne)
                   .HasMaxLength(200)
                   .HasColumnName("address_one");

            builder.Property(e => e.AddressTwo)
                   .HasMaxLength(200)
                   .HasColumnName("address_two");

            builder.Property(e => e.City)
                   .HasMaxLength(100)
                   .HasColumnName("city");

            builder.Property(e => e.State)
                   .HasMaxLength(100)
                   .HasColumnName("state");

            builder.Property(e => e.ZipCode)
                   .HasColumnName("zip_code");

            builder.Property(e => e.IsOver18)
                   .HasColumnName("is_over_18");

            builder.Property(e => e.IsCitizen)
                   .HasColumnName("is_citizen");

            builder.Property(e => e.UserId)
                   .HasColumnName("user_id");

            builder.Property(e => e.CreatedAt)
                   .HasColumnType("datetime2")
                   .HasColumnName("created_at");

            builder.Property(e => e.UpdatedAt)
                   .HasColumnType("datetime2")
                   .HasColumnName("updated_at");
        }
    }
}

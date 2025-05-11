
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using CbMaker.Domain;
namespace CbMaker.Infrastructure.Context.EntitiesConfiguration
{
    internal sealed class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("tb_users");

            builder.HasKey(e => e.UserId)
                   .HasName("users_pkey");

            builder.HasIndex(e => e.ExternalId, "users_externalid_key")
                   .IsUnique();

            builder.Property(e => e.UserId)
                   .ValueGeneratedOnAdd()
                   .HasColumnName("user_id");

            builder.Property(e => e.ExternalId)
                   .HasDefaultValueSql("NEWID()")
                   .HasColumnName("external_id");

            builder.Property(e => e.Username)
                   .HasMaxLength(100)
                   .HasColumnName("username");

            builder.Property(e => e.Tag)
                   .HasMaxLength(50)
                   .HasColumnName("tag");

            builder.Property(e => e.Email)
                   .HasMaxLength(100)
                   .HasColumnName("email");

            builder.Property(e => e.EmailConfirmed)
                   .HasMaxLength(10)
                   .HasColumnName("email_confirmed");

            builder.Property(e => e.PhoneNumber)
                   .HasColumnName("phone_number");

            builder.Property(e => e.PhoneNumberConfirmed)
                   .HasColumnName("phone_number_confirmed");

            builder.Property(e => e.TwoFactorEnabled)
                   .HasColumnName("two_factor_enabled");

            builder.Property(e => e.HashPassword)
                   .HasMaxLength(200)
                   .HasColumnName("hash_password");

            builder.Property(e => e.CreatedAt)
                   .HasColumnType("datetime2")
                   .HasColumnName("created_at");

            builder.Property(e => e.UpdatedAt)
                   .HasColumnType("datetime2")
                   .HasColumnName("updated_at");

            builder.Property(e => e.DeletedAt)
                   .HasColumnType("datetime2")
                   .HasColumnName("deleted_at");
        }
    }
}

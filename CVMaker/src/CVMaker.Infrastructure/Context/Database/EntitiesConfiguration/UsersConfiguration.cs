using CVMaker.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Update;

namespace CVMaker.Infrastructure.Context.EntitiesConfiguration
{
 internal sealed class UsersConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasKey(e => e.UserId).HasName("users_pkey");
        builder.ToTable("tb_users");
        builder.HasIndex(e => e.ExternalId, "users_externalid_key").IsUnique();

        builder.Property(e => e.UserId)
            .ValueGeneratedOnAdd()
            .HasColumnName("userid");

        builder.Property(e => e.ExternalId)
            .HasDefaultValueSql("NEWID()")
            .HasColumnName("external_id");

        builder.Property(e => e.Username)
            .HasMaxLength(250)
            .HasColumnName("username");

        builder.Property(e => e.Tag)
            .HasMaxLength(100)
            .HasColumnName("tag");
 
        builder.Property(e => e.Email)
            .HasMaxLength(250)
            .HasColumnName("email");

        builder.Property(e => e.EmailConfirmed)
            .HasColumnName("emailconfirmed");

        builder.Property(e => e.PhoneNumber)
            .HasMaxLength(100)
            .HasColumnName("phonenumber");

        builder.Property(e => e.PhoneNumberConfirmed)
            .HasColumnName("phonenumberconfirmed");

        builder.Property(e => e.TwoFactorEnabled)
            .HasColumnName("twofactorenabled");

        builder.Property(e => e.HashPassword)
            .HasMaxLength(500)
            .HasColumnName("hashpassword");

        builder.Property(e => e.CreatedAt)
            .HasColumnType("datetime2")
            .HasColumnName("createdat");

        builder.Property(e => e.UpdatedAt)
            .HasColumnType("datetime2")
            .HasColumnName("updatedat");

        builder.Property(e => e.DeletedAt)
            .HasColumnType("datetime2")
            .HasColumnName("deletedat");

        builder.HasMany(e => e.AcademicHistory)
            .WithOne(e => e.Users)
            .HasForeignKey(e => e.UserId);

        builder.HasMany(e => e.WorkExperience)
            .WithOne(e => e.Users)
            .HasForeignKey(e => e.UserId);

        builder.HasMany(e => e.UserInfo)
            .WithOne(e => e.Users)
            .HasForeignKey(e => e.UserId);

        builder.HasOne(e => e.UserSkills)
            .WithOne(us => us.User)
            .HasForeignKey<UsersSkills>(us => us.UserId);

            
            builder.Property(e => e.HashSalting)
            .HasMaxLength(500)
            .HasColumnName("hash_salting");



        builder
        .Property(e => e.UpdatedAt)
        .HasColumnType("datetime2")
        .HasColumnName("updatedat_at");

        builder
        .HasMany(af => af.AcademicHistory)
        .WithOne(ah => ah.Users)
        .HasForeignKey(ah => ah.UserId)
        .OnDelete(DeleteBehavior.ClientSetNull);

        builder
        .HasMany(af => af.AcademicHistory)
        .WithOne(ah => ah.Users)
        .HasForeignKey(ah => ah.UserId)
        .OnDelete(DeleteBehavior.ClientSetNull);

        builder
        .HasMany(af => af.WorkExperience)
        .WithOne(ah => ah.Users)
        .HasForeignKey(ah => ah.UserId)
        .OnDelete(DeleteBehavior.ClientSetNull);

        builder
        .HasMany(af => af.UserInfo)
        .WithOne(ah => ah.Users)
        .HasForeignKey(ah => ah.UserId)
        .OnDelete(DeleteBehavior.ClientSetNull);






        

    }
}   
}
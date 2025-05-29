using CVMaker.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CVMaker.Infrastructure.Context.EntitiesConfiguration
{
    internal sealed class LanguageConfiguration : IEntityTypeConfiguration<Language>
    {
        public void Configure(EntityTypeBuilder<Language> builder)
        {
            builder.HasKey(e => e.languageId).HasName("languages_pkey");
            builder.ToTable("tb_languages");
            builder.HasIndex(e => e.ExternalId, "languages_externalid_key").IsUnique();

            builder.Property(e => e.languageId)
                .ValueGeneratedOnAdd()
                .HasColumnName("languageid");

            builder.Property(e => e.ExternalId)
                .HasDefaultValueSql("NEWID()")
                .HasColumnName("external_id");

            builder.Property(e => e.description)
                .HasMaxLength(500)
                .HasColumnName("description");

            builder.Property(e => e.createdAt)
                .HasColumnType("datetime2")
                .HasColumnName("createdat");

            builder.Property(e => e.updatedAt)
                .HasColumnType("datetime2")
                .HasColumnName("updatedat");

            builder.HasMany(e => e.UserInfoLanguage)
                .WithOne(e => e.Languages)
                .HasForeignKey(e => e.LanguageId);


            builder
            .HasMany(af => af.UserInfoLanguage)
            .WithOne(ah => ah.Languages)
            .HasForeignKey(ah => ah.LanguageId)
            .OnDelete(DeleteBehavior.ClientSetNull);

            builder.HasData([
                new Language{languageId =1, description = "Espanol"},
                new Language{languageId =2, description = "Ingles"}, 
                new Language{languageId =3, description = "Frances"},
                new Language{languageId =4, description = "Almenan"},
                new Language{languageId =5, description = "Italiano"},     
            ]);
        }
    }
}
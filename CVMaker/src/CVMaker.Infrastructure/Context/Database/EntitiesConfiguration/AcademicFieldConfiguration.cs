using CVMaker.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace CVMaker. Infrastructure.Context.EntitiesConfiguration
{
    internal sealed class AcademicfieldConfiguration: IEntityTypeConfiguration<AcademicFields>
    {
        public void Configure (EntityTypeBuilder <AcademicFields> builder)
        {

    builder.HasKey(e => e.AcademicFieldsID).HasName("academic_fields_pkey");
    builder.ToTable("tb_academic_fields");
    builder.HasIndex(e => e.ExternalID, "academic_fields_externalid_key").IsUnique();
    builder.Property(e => e.AcademicFieldsID)
       .ValueGeneratedOnAdd()
       .HasColumnName("academic_field_id");
    builder.Property(e => e.CreatedAt)
       .HasColumnType("DateTime2")
       .HasColumnName("created_at");
    builder.Property(e=> e.Description) .HasMaxLength(500)
       .HasColumnName("description");
    builder.Property(e => e.ExternalID)
       .HasDefaultValueSql("NEWID()")
       .HasColumnName("external_id");
    builder.Property(e => e.UpdatedAt)
       .HasColumnType("DateTime")  
       .HasColumnName("updated_at");
     builder.Property(e => e.UpdatedAt)
         .HasColumnType("DateTime2")
         .HasColumnName("updated_at");

         builder
         .HasMany(af => af.AcademicHistories)
         .WithOne(ah => ah.AcademicField)
         .HasForeignKey(ah => ah.AcademicFieldId)
         .OnDelete(DeleteBehavior.ClientSetNull);

       

        }

    }

}
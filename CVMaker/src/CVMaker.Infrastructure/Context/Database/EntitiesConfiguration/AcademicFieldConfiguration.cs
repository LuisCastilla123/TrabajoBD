using CVMaker.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace CVMaker. Infrastructure.Context.EntitiesConfiguration
{
    internal sealed class AcademicfieldConfiguration: IEntityTypeConfiguration<AcademicField>
    {
        public void Configure (EntityTypeBuilder <AcademicField> builder)
        {

    builder.HasKey(e => e.AcademicFieldsID).HasName("academic_fields_pkey");
    builder.ToTable("tb_academic_fields");
    builder.HasIndex(e => e.ExternalID, "academic_fields_externalid_key").IsUnique();
    builder.Property(e => e.AcademicFieldsID)
       .ValueGeneratedOnAdd()
       .HasColumnName("academic_field_id");
    builder.Property(e => e.CreatedAt)
       .HasColumnType("datetime2")
       .HasColumnName("created_at");
    builder.Property(e=> e.Description) .HasMaxLength(500)
       .HasColumnName("description");
    builder.Property(e => e.ExternalID)
       .HasDefaultValueSql("NEWID()")
       .HasColumnName("external_id");
     builder.Property(e => e.UpdatedAt)
         .HasColumnType("datetime2")
         .HasColumnName("updated_at");

         builder
         .HasMany(af => af.AcademicHistories)
         .WithOne(ah => ah.academicField)
         .HasForeignKey(ah => ah.AcademicFieldId)
         .OnDelete(DeleteBehavior.ClientSetNull);

       builder.HasData([
        new AcademicField{AcademicFieldsID =1, Description = "Ciencias Sociales"},
         new AcademicField{AcademicFieldsID =2, Description = "Ciencias Naturales"},
         new AcademicField{AcademicFieldsID =3, Description = "Matematicas"},
         new AcademicField{AcademicFieldsID =4, Description = "Ingeneria"},
         new AcademicField{AcademicFieldsID =5, Description = "Tecnologia de la Informacion"},
         new AcademicField{AcademicFieldsID =6, Description = "Ciencias de la Salud"},
         new AcademicField{AcademicFieldsID =7, Description = "Ciencias de la Educacion"},
         new AcademicField{AcademicFieldsID =8, Description = "Artes"},
         new AcademicField{AcademicFieldsID =9, Description = "Ciencias Economicas"},
         new AcademicField{AcademicFieldsID =10, Description = "Ciencias Politicas"},
       ]);

        }

    }

}
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

       builder.HasData([
         new AcademicFields{AcademicFieldsID =1, Description = "Ciencias Sociales"},
         new AcademicFields{AcademicFieldsID =2, Description = "Ciencias Naturales"},
         new AcademicFields{AcademicFieldsID =3, Description = "Matematicas"},
         new AcademicFields{AcademicFieldsID =4, Description = "Ingeneria"},
         new AcademicFields{AcademicFieldsID =5, Description = "Tecnologia de la Informacion"},
         new AcademicFields{AcademicFieldsID =6, Description = "Ciencias de la Salud"},
         new AcademicFields{AcademicFieldsID =7, Description = "Ciencias de la Educacion"},
         new AcademicFields{AcademicFieldsID =8, Description = "Artes"},
         new AcademicFields{AcademicFieldsID =9, Description = "Ciencias Economicas"},
         new AcademicFields{AcademicFieldsID =10, Description = "Ciencias Politicas"},
       ]);

        }

    }

}
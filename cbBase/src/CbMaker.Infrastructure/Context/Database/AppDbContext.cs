
using Microsoft.EntityFrameworkCore;
using CbMaker.Infrastructure;
using CbMaker.Domain;




namespace CbMaker.Infrastructure.Context.Database
{
    public sealed class AppDbContext : DbContext
    {

        public AppDbContext() {}


        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<AcademicField> AcademiFields { get; set; }
        public DbSet<AcademicHistory> AcademicHistories { get; set; }
        public DbSet<Degree> Degrees { get; set; }
        public DbSet<JobTitle> JobTitles { get; set; }
        public DbSet<Language> Languages { get; set; }
        public DbSet<Skill> Skills { get; set; }
        public DbSet<UserInfoLanguage> UserInfoLanguages { get; set; }
        public DbSet<UserInfo> UserInfos { get; set; }
        public DbSet<UserSkill> UserSkills { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<WorkExperience> WorkExperiences { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
            modelBuilder.HasDefaultSchema("dbo");
        }
    
  protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
{
    if (!optionsBuilder.IsConfigured)
    {
        string connectionString = @"Server=VDZ;Database=CVMakerDB;Trusted_Connection=True;Encrypt=False;";
        optionsBuilder.UseSqlServer(connectionString);
    }
}


    }
}


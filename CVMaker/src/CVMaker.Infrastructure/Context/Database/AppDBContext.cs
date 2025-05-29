using CVMaker.Application.Abstractions;
using CVMaker.Application.Abstractions.Data;
using CVMaker.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;

namespace CVMarker.Infrastructure.Context.Database
{
    public sealed class AppDBContext : DbContext, IApplicationDBContext, IUnitOfWork
       {
        public AppDBContext() { }
        public AppDBContext(DbContextOptions<AppDBContext> options) 
            : base(options) { }
        public DbSet<AcademicField> AcademicFields { get; set; }
        public DbSet<UsersInfo> Users_Infos { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Skills> Skill { get; set; }
        public DbSet<JobTitles> JobTitle { get; set; }
        public DbSet<Degrees> Degrees { get; set; }
        public DbSet<Language> Languages { get; set; }
        public DbSet<AcademicHistory> AcademicHistory { get; set; }
        public DbSet<UsersSkills> Users_Skills { get; set; }
        public DbSet<UsersInfoLanguages> Users_Info_Languages { get; set; }
        public DbSet<WorkExperiences> WorkExperiences { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDBContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }
       protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
       {
           if (!optionsBuilder.IsConfigured)
           {
               string connectionString = @"Server=DESKTOP-C3SBGOG\SQLEXPRESS;
                   Database=CVMakerDB;
                   Trusted_Connection=True;
                   Encrypt=False;";
                optionsBuilder.UseSqlServer(connectionString);
         }
          }
        

        public Task BeginTransactionAsync(CancellationToken CancellationToken = default)
        {
            return Database.BeginTransactionAsync(CancellationToken);  
        }

        public async Task CommitAsync(CancellationToken CancellationToken = default)
        {
            var transaction = Database.CurrentTransaction;
            if (transaction != null)
            {
                await transaction.CommitAsync(CancellationToken);
            }
        }

        public async Task RollbackAsync(CancellationToken CancellationToken = default)
        {
            
            var transaction = Database.CurrentTransaction;
            if (transaction != null)
            {
                await transaction.RollbackAsync(CancellationToken);
            }
        }

       

        public override async Task<int> SaveChangesAsync(CancellationToken CancellationToken = default)
        {
            int result = await base.SaveChangesAsync(CancellationToken);
            return result;
        }
    }
}

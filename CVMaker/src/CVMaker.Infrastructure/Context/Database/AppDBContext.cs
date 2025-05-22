using CVMaker.Application.Abstractions;
using CVMaker.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;

namespace CVMarker.Infrastructure.Context.Database
{
    public sealed class AppDBContext : DbContext, IAplicationDBContextes, IUnitOfWork
       {
        public AppDBContext() { }
        public AppDBContext(DbContextOptions<AppDBContext> options) 
            : base(options) { }
        public DbSet<AcademicField> AcademicField { get; set; }
        public DbSet<UsersInfo> UserInfo { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Skills> Skill { get; set; }
        public DbSet<JobTitles> JobTitle { get; set; }
        public DbSet<Degrees> Degree { get; set; }
        public DbSet<Language> Languages { get; set; }
        public DbSet<AcademicHistory> AcademicHistorys { get; set; }
        public DbSet<UsersSkills> UserSkills { get; set; }
        public DbSet<UsersInfoLanguages> UserInfoLanguage { get; set; }
        public DbSet<WorkExperiences> WorkExperience { get; set; }

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

    internal interface IAplicationDBContextes
    {
    }
}

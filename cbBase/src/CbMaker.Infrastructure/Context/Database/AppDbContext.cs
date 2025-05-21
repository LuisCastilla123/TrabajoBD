using Microsoft.EntityFrameworkCore;
using CbMaker.Application.Abstractions.Data;
using CbMaker.Domain;
using CbMaker.Infrastructure;

namespace CbMaker.Infrastructure.Context.Database
{
    public sealed class AppDbContext : DbContext, IApplicationDbContext, IUnitOfWork
    {
        public AppDbContext() { }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<AcademicField> AcademicFields { get; set; }
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

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            int result = await base.SaveChangesAsync(cancellationToken);
            return result;
        }

        public Task BeginTransactionAsync(CancellationToken cancellationToken = default)
        {
            return Database.BeginTransactionAsync(cancellationToken);
        }

        public async Task CommitAsync(CancellationToken cancellationToken = default)
        {
            var transaction = Database.CurrentTransaction;
            if (transaction != null)
            {
                await transaction.CommitAsync(cancellationToken);
            }
        }

        public async Task RollbackAsync(CancellationToken cancellationToken = default)
        {
            var transaction = Database.CurrentTransaction;
            if (transaction != null)
            {
                await transaction.RollbackAsync(cancellationToken);
            }
        }

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

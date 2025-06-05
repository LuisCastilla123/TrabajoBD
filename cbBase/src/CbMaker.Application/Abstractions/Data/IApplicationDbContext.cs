using CbMaker.Domain;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;


namespace CbMaker.Application.Abstractions.Data
  
{
    public interface IApplicationDbContext
    {
        DbSet<AcademicField> AcademicFields { get; set; }
        DbSet<AcademicHistory> AcademicHistories { get; set; }
        DbSet<Degree> Degrees { get; set; }
        DbSet<JobTitle> JobTitles { get; set; }
        DbSet<Language> Languages { get; set; }
        DbSet<Skill> Skills { get; set; }
        DbSet<UserInfoLanguage> UserInfoLanguages { get; set; }
        DbSet<UserInfo> UserInfos { get; set; }
        DbSet<UserSkill> UserSkills { get; set; }
        DbSet<User> Users { get; set; }
        DbSet<WorkExperience> WorkExperiences { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}

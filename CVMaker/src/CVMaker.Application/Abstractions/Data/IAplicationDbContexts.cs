namespace CVMaker.Aplication.Abstractions.Data

using CVMaker.Domain.Entities.AcademicField;
using CVMaker.Domain.Entities.AcademicHistory;
using CVMaker.Domain.Entities.Degree;
using CVMaker.Domain.Entities.JobTitles;
using CVMaker.Domain.Entities.Skills;
using CVMaker.Domain.Entities.Users;
using CVMaker.Domain.Entities.UserInfo;
using CVMaker.Domain.Entities.UserInfoLanguage;
using CVMaker.Domain.Entities.UserSkills;
using CVMaker.Domain.Entities.WorkExperiences;
using CVMaker.Domain.Entities.AcademicField;
using Microsoft.EntitiesFrameworkCore;
{
    public interface IAplicationDbContexts
    {
        public DbSet<AcademicFields> AcademicField { get; set; }
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
    }
}
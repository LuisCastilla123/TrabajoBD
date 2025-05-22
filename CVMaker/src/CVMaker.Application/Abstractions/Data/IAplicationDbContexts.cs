using CVMaker.Domain.Entities;
using Microsoft.EntityFrameworkCore;


namespace CVMaker.Application.Abstractions.Data
{
    public interface IApplicationDBContext
    {

        DbSet<AcademicField> AcademicFields { get; set; }
        DbSet<AcademicHistory> AcademicHistory { get; set; }
        DbSet<Degrees> Degrees { get; set; }
        DbSet<JobTitles> JobTitle { get; set; }
        DbSet<Language> Languages { get; set; }
        DbSet<Skills> Skill { get; set; }
        DbSet<UsersInfoLanguages> Users_Info_Languages { get; set; }
        DbSet<UsersInfo> Users_Infos { get; set; }
        DbSet<UsersSkills> Users_Skills { get; set; }
        DbSet<User> Users { get; set; }
        DbSet<WorkExperiences> WorkExperiences { get; set; }
    }

}
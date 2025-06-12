using CVMaker.Application.Abstractions.Data;
using CVMaker.Application.Abstractions.Messaging;
using CVMaker.Application.DTOs;
using CVMaker.SharedKernel;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace CVMaker.Application.Features.Cv.Get
{
    internal sealed class GetCVQueryHandler : IQueryHandler<GetCVQuery, CVResponse>
    {
        private readonly IApplicationDBContext _context;
        private readonly ILogger<GetCVQueryHandler> _logger;

        public GetCVQueryHandler(IApplicationDBContext context, ILogger<GetCVQueryHandler> logger)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<Result<CVResponse>> Handle(GetCVQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var user = await _context.Users
                    .Include(u => u.UserInfo)
                        .Include(ui => ui.UsersSkills)
                            .ThenInclude(s => s.Skill)
                    .Include(u => u.UserInfo)
                        .ThenInclude(ui => ui.UserInfoLanguage)
                            .ThenInclude(l => l.Languages)
                    .Include(u => u.AcademicHistory)
                        .ThenInclude(ah => ah.Degree)
                    .Include(u => u.AcademicHistory)
                        .ThenInclude(ah => ah.academicField)
                    .Include(u => u.WorkExperience)
                        .ThenInclude(we => we.JobTitle)
                    .FirstOrDefaultAsync(u => u.ExternalId == request.UserId, cancellationToken);

                if (user == null)
                {
                    _logger.LogWarning("User with UserId: {UserId} not found.", request.UserId);
                    return Result<CVResponse>.Failure(Error.NotFound(
                        "User.NotFound",
                        "The user with the specified ID does not exist."
                    ));
                }

                var userInfo = user.UserInfo.FirstOrDefault();

                var cv = new CVResponse
                {
                    User = new UserResponse
                    {
                        UserId = user.ExternalId,
                        UserName = user.Username,
                        Email = user.Email,
                        PhoneNumber = user.PhoneNumber,
                        UserInfo = userInfo == null ? null : new UserInfoResponse
                        {
                            Location = userInfo.Location,
                            About = userInfo.About,
                            Skills = user.UsersSkills?
                                .Where(s => s.Skill != null)
                                .Select(s => new OptionDTO
                                {
                                    Id = s.Skill.ExternalId,
                                    
                                    Name = s.Skill.Description
                                }).ToList(),
                            Languages = userInfo.UserInfoLanguage?
                                .Where(l => l.Languages != null)
                                .Select(l => new OptionDTO
                                {
                                    Id = l.Languages.ExternalId,
                                   
                                    Name = l.Languages.description
                                }).ToList()
                        },
                        AcademicHistories = user.AcademicHistory.Select(ah => new AcademicHistoryResponse
                        {
                            AcademicHistoryId = ah.ExternalID,
                            InstitutionName = ah.InstitutionName,
                            Speciality = ah.Speciality,
                            Degree = ah.Degree == null ? null : new OptionDTO
                            {
                                Id = ah.Degree.ExternalId,
                               
                                Name = ah.Degree.Description
                            },
                            AcademicField = ah.academicField == null ? null : new OptionDTO
                            {
                                Id = ah.academicField.ExternalID,
                              
                                Name = ah.academicField.Description
                            },
                            StartDate = ah.StartDate,
                            EndDate = ah.EndDate
                        }).ToList(),
                        WorkExperiences = user.WorkExperience.Select(we => new WorkExperienceResponse
                        {
                            WorkExperienceId = we.ExternalId,
                            EnterpriseName = we.EnterpriseName,
                            StartDate = we.StartDate,
                            EndDate = we.EndDate,
                            JobTitle = we.JobTitle == null ? null : new OptionDTO
                            {
                                Id = we.JobTitle.ExternalId ,
                                
                                Name = we.JobTitle.Description
                            },
                            Description = we.Description
                        }).ToList()
                    },
                    UpdatedAt = user.CreatedAt
                };

                _logger.LogInformation("Successfully retrieved CV for userId: {UserId}", request.UserId);
                return Result<CVResponse>.Success(cv);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while handling GetCVQuery for userId: {UserId}", request.UserId);
                return Result<CVResponse>.Failure(Error.Problem(
                    "CVQuery.Failure",
                    "An unexpected error occurred while processing your request. Please try again later."
                ));
            }
        }
    }
}

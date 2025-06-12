using CVMaker.Application.DTOs;

namespace CVMaker.Application.Features.Cv.Get
{
    public class CVResponse
    {
        public UserResponse User { get; set; } = new UserResponse();
        public DateTime UpdatedAt { get; set; }
    }

    public class UserResponse
    {
        public Guid UserId { get; set; }
        public string UserName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public UserInfoResponse UserInfo { get; set; } = new UserInfoResponse();
        public List<AcademicHistoryResponse> AcademicHistories { get; set; } = new List<AcademicHistoryResponse>();
        public List<WorkExperienceResponse> WorkExperiences { get; set; } = new List<WorkExperienceResponse>();
    }

    public class UserInfoResponse
    {
        public string Location { get; set; } = string.Empty;
        public string? About { get; set; }
        public List<OptionDTO> Skills { get; set; } = new List<OptionDTO>();
        public List<OptionDTO> Languages { get; set; } = new List<OptionDTO>();
    }

    public class AcademicHistoryResponse
    {
        public Guid AcademicHistoryId { get; set; }
        public string InstitutionName { get; set; } = string.Empty;
        public string Speciality { get; set; } = string.Empty;
        public OptionDTO Degree { get; set; } = new OptionDTO();
        public OptionDTO AcademicField { get; set; } = new OptionDTO();
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
    }

    public class WorkExperienceResponse
    {
        public Guid WorkExperienceId { get; set; }
        public string EnterpriseName { get; set; } = string.Empty;
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public OptionDTO JobTitle { get; set; } = new OptionDTO();
        public string? Description { get; set; }
    }
}

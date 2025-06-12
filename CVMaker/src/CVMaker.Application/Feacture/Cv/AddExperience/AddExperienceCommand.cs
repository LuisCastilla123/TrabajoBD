using CVMaker.Application.Abstractions.Messaging;

namespace CVMaker.Application.Features.Cv.AddExperience
{
    public record AddExperienceCommand(
        string EnterpriseName,
        DateTime StartDate,
        DateTime? EndDate,
        string? Description,
        Guid? JobTitleId,
        Guid UserId
    ) : ICommand;
}

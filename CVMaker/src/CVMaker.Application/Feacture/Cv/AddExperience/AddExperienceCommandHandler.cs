using CVMaker.Application.Abstractions;
using CVMaker.Application.Abstractions.Data;
using CVMaker.Application.Abstractions.Messaging;
using CVMaker.Domain.Entities;
using CVMaker.SharedKernel;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace CVMaker.Application.Features.Cv.AddExperience
{
    internal sealed class AddExperienceCommandHandler : ICommandHandler<AddExperienceCommand>
    {
        private readonly IApplicationDBContext _context;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<AddExperienceCommandHandler> _logger;

        public AddExperienceCommandHandler(
            IApplicationDBContext context,
            IUnitOfWork unitOfWork,
            ILogger<AddExperienceCommandHandler> logger)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<Result> Handle(AddExperienceCommand request, CancellationToken cancellationToken)
        {
            try
            {
                await _unitOfWork.BeginTransactionAsync(cancellationToken);

                var user = await _context.Users
                    .FirstOrDefaultAsync(x => x.ExternalId == request.UserId, cancellationToken);

                if (user == null)
                {
                    return Result.Failure(Error.NotFound("UserNotFound", "The specified user does not exist."));
                }

                JobTitles? jobTitle = null;
                if (request.JobTitleId.HasValue)
                {
                    jobTitle = await _context.JobTitle
                        .FirstOrDefaultAsync(x => x.ExternalId == request.JobTitleId.Value, cancellationToken);

                    if (jobTitle == null)
                    {
                        return Result.Failure(Error.NotFound("JobTitleNotFound", "The specified job title does not exist."));
                    }
                }

                var experience = WorkExperiences.Create(
                    request.EnterpriseName,
                    request.StartDate,
                    request.EndDate,
                    request.Description,
                    jobTitle?.JobTitleId,
                    user.UserId
                );

                _context.WorkExperiences.Add(experience);

                await _unitOfWork.SaveChangesAsync(cancellationToken);
                await _unitOfWork.CommitAsync(cancellationToken);
                _logger.LogInformation("Experience added successfully for user {UserId}", request.UserId);
                return Result.Success();
            }
            catch(Exception ex)
            {
                _logger.LogError(ex, "Error adding experience for user {UserId}", request.UserId);
                await _unitOfWork.RollbackAsync(cancellationToken);
                return Result.Failure(Error.Problem("UnhandledExeption", "An unexpected error ocurred. Please try again later."));
            }
        }
    }
}

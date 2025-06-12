using CVMaker.Application.Abstractions;
using CVMaker.Application.Abstractions.Data;
using CVMaker.Application.Abstractions.Messaging;
using CVMaker.SharedKernel;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CVMaker.Application.Features.Cv.AddSkill
{
    internal sealed class AddSkillCommandHandler : ICommandHandler<AddSkillCommand>
    {
        private readonly IApplicationDBContext _context;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<AddSkillCommandHandler> _logger;

        public AddSkillCommandHandler(
            IApplicationDBContext context,
            IUnitOfWork unitOfWork,
            ILogger<AddSkillCommandHandler> logger)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<Result> Handle(AddSkillCommand request, CancellationToken cancellationToken)
        {
            try
            {
                await _unitOfWork.BeginTransactionAsync(cancellationToken);

                var user = await _context.Users
                    .Include(x => x.UsersSkills)
                    .FirstOrDefaultAsync(x => x.ExternalId == request.UserId, cancellationToken);

                if (user == null)
                {
                    return Result.Failure(Error.NotFound("UserNotFound", "The specified user does not exist."));
                }

                var skill = await _context.Skill
                    .FirstOrDefaultAsync(x => x.ExternalId == request.SkillId, cancellationToken);

                if (skill == null)
                {
                    return Result.Failure(Error.NotFound("SkillNotFound", "The specified skill does not exist."));
                }

                if (user.UsersSkills.Any(x => x.ExternalID == request.SkillId))
                {
                    return Result.Failure(Error.Conflict("SkillAlreadyAdded", "The skill has already been added to the user's CV."));
                }

                user.AddSkill(skill.SkillId);

                await _unitOfWork.SaveChangesAsync(cancellationToken);
                await _unitOfWork.CommitAsync(cancellationToken);

                _logger.LogInformation("Skill added to user's CV successfully");

                return Result.Success();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error adding skill to user's CV");
                await _unitOfWork.RollbackAsync(cancellationToken);
                return Result.Failure(Error.Problem("UnhandledException", "An unexpected error occurred. Please try again later."));
            }
        }
    }
}

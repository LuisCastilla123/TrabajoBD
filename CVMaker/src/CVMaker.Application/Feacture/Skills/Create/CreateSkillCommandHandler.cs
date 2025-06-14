using CVMaker.Application.Abstractions;
using CVMaker.Application.Abstractions.Data;
using CVMaker.Application.Abstractions.Messaging;
using CVMaker.SharedKernel;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace CVMaker.Application.Features.Skills.Create
{
    internal sealed class CreateSkillsCommandHandler : ICommandHandler<CreateSkillsCommand>
    {
        private readonly IApplicationDBContext _context;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<CreateSkillsCommand> _logger;

        public CreateSkillsCommandHandler(
            IApplicationDBContext context,
            IUnitOfWork unitOfWork,
            ILogger<CreateSkillsCommand> logger)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }
        public async Task<Result> Handle(CreateSkillsCommand request, CancellationToken
    cancellationToken)
        {
            try
            {
                await _unitOfWork.BeginTransactionAsync(cancellationToken);

                var SkillExists = await _context.Skill
                    .AnyAsync(x => x.Description == request.Description, cancellationToken);

                if (SkillExists)
                {
                    return Result.Failure(Error.Conflict(
                        "DegreeAlreadyExists",
                        "The degree already exists."
                    ));
                }

                var skill = Domain.Entities.Skills.Create(request.Description);

                await _context.Skill.AddAsync(skill, cancellationToken); 

                await _unitOfWork.SaveChangesAsync(cancellationToken);
                await _unitOfWork.CommitAsync (cancellationToken);
                _logger.LogInformation("Degree created successfully");
                return Result.Success();   
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error creating degree");
                await _unitOfWork.RollbackAsync(cancellationToken);
                return Result.Failure(Error.Problem(
                    "UnhandledException",
                    "An unexpected error occurred. Please try again later."
                ));
            }
        }

    }
}

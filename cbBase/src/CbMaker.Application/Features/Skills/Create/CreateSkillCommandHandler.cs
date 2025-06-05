using CbMaker.Application.Abstractions.Data;
using CbMaker.Application.Abstractions.Messaging;
using CbMaker.Domain;
using CbMaker.SharedKernel;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;


namespace CbMaker.Application.Features.Skills.Create
{
    internal sealed class CreateSkillCommandHandler : ICommandHandler<CreateSkillCommand, Unit>
    {
        private readonly IApplicationDbContext _context;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<CreateSkillCommandHandler> _logger;

        public CreateSkillCommandHandler(
            IApplicationDbContext context,
            IUnitOfWork unitOfWork,
            ILogger<CreateSkillCommandHandler> logger)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<Result<Unit>> Handle(CreateSkillCommand request, CancellationToken cancellationToken)
        {
            try
            {
                await _unitOfWork.BeginTransactionAsync(cancellationToken);

                var skillExists = await _context.Skills
                    .AnyAsync(x => x.Description == request.Description, cancellationToken);

                if (skillExists)
                {
                    return Result.Failure<Unit>(Error.Conflict(
                        "SkillAlreadyExists", "The skill already exists."));
                }

                var skill = Skill.Create(request.Description);

                await _context.Skills.AddAsync(skill, cancellationToken);
                await _unitOfWork.SaveChangesAsync(cancellationToken);
                await _unitOfWork.CommitAsync(cancellationToken);

                _logger.LogInformation("Skill created successfully.");
                return Result.Success(Unit.Value);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error creating skill.");
                await _unitOfWork.RollbackAsync(cancellationToken);

                return Result.Failure<Unit>(Error.Problem(
                    "UnhandledException", "An unexpected error occurred. Please try again later."));
            }
        }
    }
}


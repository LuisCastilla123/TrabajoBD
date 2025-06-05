using MediatR;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;
using CbMaker.Domain;
using CbMaker.Application.Abstractions.Data;
using CbMaker.SharedKernel;
using CbMaker.Application.Abstractions.Messaging;


namespace CbMaker.Application.Features.JobTitles.Create
{
    public sealed class CreateJobTitleCommandHandler : ICommandHandler<CreateJobTitleCommand, Unit>
    {
        private readonly IApplicationDbContext _context;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<CreateJobTitleCommandHandler> _logger;

        public CreateJobTitleCommandHandler(
            IApplicationDbContext context,
            IUnitOfWork unitOfWork,
            ILogger<CreateJobTitleCommandHandler> logger)
        {
            _context = context;
            _unitOfWork = unitOfWork;
            _logger = logger;
        }

        public async Task<Result<Unit>> Handle(CreateJobTitleCommand request, CancellationToken cancellationToken)
        {
            try
            {
                await _unitOfWork.BeginTransactionAsync(cancellationToken);

                var exists = await _context.JobTitles.AnyAsync(x => x.Description == request.Description, cancellationToken);
                if (exists)
                    return Result.Failure<Unit>(Error.Conflict("JobTitleExists", "The job title already exists."));

                var title = new JobTitle(request.Description);
                await _context.JobTitles.AddAsync(title, cancellationToken);

                await _unitOfWork.SaveChangesAsync(cancellationToken);
                await _unitOfWork.CommitAsync(cancellationToken);

                _logger.LogInformation("Job title created.");
                return Result.Success(Unit.Value);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error creating job title.");
                await _unitOfWork.RollbackAsync(cancellationToken);
                return Result.Failure<Unit>(Error.Problem("UnhandledException", "Unexpected error."));
            }
        }
    }
}

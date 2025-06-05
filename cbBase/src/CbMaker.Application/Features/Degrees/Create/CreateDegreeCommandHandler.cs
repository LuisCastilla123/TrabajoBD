using CbMaker.Application.Abstractions.Data;
using CbMaker.Application.Abstractions.Messaging;
using CbMaker.Domain;
using CbMaker.SharedKernel;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using MediatR;


namespace CbMaker.Application.Features.Degrees.Create
{
    internal sealed class CreateDegreeCommandHandler : ICommandHandler<CreateDegreeCommand, Unit>
    {
        private readonly IApplicationDbContext _context;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<CreateDegreeCommandHandler> _logger;

        public CreateDegreeCommandHandler(
            IApplicationDbContext context,
            IUnitOfWork unitOfWork,
            ILogger<CreateDegreeCommandHandler> logger)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<Result<Unit>> Handle(CreateDegreeCommand request, CancellationToken cancellationToken)
        {
            try
            {
                await _unitOfWork.BeginTransactionAsync(cancellationToken);

                var degreeExists = await _context.Degrees
                    .AnyAsync(x => x.Description == request.Description, cancellationToken);

                if (degreeExists)
                {
                    return Result.Failure<Unit>(Error.Conflict("DegreeAlreadyExists", "The degree already exists."));
                }

                var degree = Degree.Create(request.Description);

                await _context.Degrees.AddAsync(degree, cancellationToken);
                await _unitOfWork.SaveChangesAsync(cancellationToken);
                await _unitOfWork.CommitAsync(cancellationToken);

                _logger.LogInformation("Degree created successfully.");
                return Result.Success(Unit.Value);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error creating degree.");
                await _unitOfWork.RollbackAsync(cancellationToken);

                return Result.Failure<Unit>(Error.Problem("UnhandledException", "An unexpected error occurred. Please try again later."));
            }
        }
    }
}

using CVMaker.Application.Abstractions;
using CVMaker.Application.Abstractions.Data;
using CVMaker.Application.Abstractions.Messaging;
using CVMaker.Application.Features.Degrees.Create;
using CVMaker.Domain.Entities;
using CVMaker.SharedKernel;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace CVMaker.Application.Features.Degrees.Create
{
    internal sealed class CreateDegreeCommandHandler : ICommandHandler<CreateDegreeCommand>
    {
        private readonly IApplicationDBContext _context;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<CreateDegreeCommand> _logger;

        public CreateDegreeCommandHandler(
            IApplicationDBContext context,
            IUnitOfWork unitOfWork,
            ILogger<CreateDegreeCommand> logger)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }
        public async Task<Result> Handle(CreateDegreeCommand request, CancellationToken
    cancellationToken)
        {
            try
            {
                await _unitOfWork.BeginTransactionAsync(cancellationToken);

                var degreeExists = await _context.Degrees
                    .AnyAsync(x => x.Description == request.Description, cancellationToken);

                if (degreeExists)
                {
                    return Result.Failure(Error.Conflict(
                        "DegreeAlreadyExists",
                        "The degree already exists."
                    ));
                }

                var degree = Domain.Entities.Degrees.Create(request.Description);

                await _context.Degrees.AddAsync(degree, cancellationToken); 

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
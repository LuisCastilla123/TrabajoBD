using CVMaker.Application.Abstractions.Data;
using CVMaker.Application.Abstractions.Messaging;
using CVMaker.Domain.Entities;
using CVMaker.SharedKernel;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using CVMaker.Application.Abstractions;

namespace CVMaker.Application.Features.AcademicFields.Create
{
    internal sealed class CreateProjectCommandHandler : ICommandHandler<CreateAcademicFieldCommand>
    {
        private readonly IApplicationDBContext _Context;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<CreateAcademicFieldCommand> _logger;

        public CreateProjectCommandHandler(
            IApplicationDBContext context,
            IUnitOfWork unitOfWork,
            ILogger<CreateAcademicFieldCommand> logger)
      {
        _Context = context ?? throw new ArgumentNullException(nameof(context));
        _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
      }      
        public async Task<Result> Handle (CreateAcademicFieldCommand request, CancellationToken cancellationToken)
        {
        try
        {
            await _unitOfWork.BeginTransactionAsync(cancellationToken);

            var AcademicFieldExists = await _Context.AcademicFields
                .AnyAsync(x => x.Description == request.Description, cancellationToken);
            if (AcademicFieldExists)
            {
                return Result.Failure(Error.Conflict(
                    "AcademicFieldalreadyexists",
                    "The Academic Field already exists."
                ));
            }
            var academicField = AcademicField.Create(request.Description);
            await _Context.AcademicFields.AddAsync(academicField, cancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
            await _unitOfWork.CommitAsync(cancellationToken);
            _logger.LogInformation("Academic Field created successfully");
            return Result.Success();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error creating Academic Field");
            await _unitOfWork.RollbackAsync(cancellationToken);
            return Result.Failure(Error.Problem(
                "unhandledException",
                "An unexpected error occurred .Please try again later."
            ));
        }
            
        }
    }
        
}
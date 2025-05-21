using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using CbMaker.Application.Abstractions.Data;
using CbMaker.Domain;
using CbMaker.SharedKernel;

namespace CbMaker.Application.Features.AcademicFields.Create
{
    public sealed class CreateAcademicFieldCommandHandler : IRequestHandler<CreateAcademicFieldCommand, Result<Guid>>
    {
        private readonly IApplicationDbContext _context;

        public CreateAcademicFieldCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Result<Guid>> Handle(CreateAcademicFieldCommand request, CancellationToken cancellationToken)
        {
            var entity = new AcademicField
            {
                ExternalId = Guid.NewGuid(),
                Description = request.Description,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };

            await _context.AcademicFields.AddAsync(entity, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);

            return Result.Success(entity.ExternalId);
        }
    }
}

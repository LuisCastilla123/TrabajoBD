using CbMaker.Application.Abstractions.Data;
using CbMaker.Application.Abstractions.Messaging;
using CbMaker.Application.DTOs;
using CbMaker.SharedKernel;
using Microsoft.EntityFrameworkCore;

namespace CbMaker.Application.Features.Platform.Options.Get
{
    internal sealed class GetOptionsQueryHandler : IQueryHandler<GetOptionsQuery, OptionsResponse>
    {
        private readonly IApplicationDbContext _context;

        public GetOptionsQueryHandler(IApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<Result<OptionsResponse>> Handle(GetOptionsQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var academicFields = await _context.AcademicFields
                    .AsNoTracking()
                    .Select(x => new OptionDTO(x.ExternalId, x.Description))
                    .ToListAsync(cancellationToken);

                var degrees = await _context.Degrees
                    .AsNoTracking()
                    .Select(x => new OptionDTO(x.ExternalId, x.Description))
                    .ToListAsync(cancellationToken);

                var jobTitles = await _context.JobTitles
                    .AsNoTracking()
                    .Select(x => new OptionDTO(x.ExternalId, x.Description))
                    .ToListAsync(cancellationToken);

                var languages = await _context.Languages
                    .AsNoTracking()
                    .Select(x => new OptionDTO(x.ExternalId, x.Description))
                    .ToListAsync(cancellationToken);

                var skills = await _context.Skills
                    .AsNoTracking()
                    .Select(x => new OptionDTO(x.ExternalId, x.Description))
                    .ToListAsync(cancellationToken);

                var options = new OptionsResponse
                {
                    AcademicFields = academicFields,
                    Degrees = degrees,
                    JobTitles = jobTitles,
                    Languages = languages,
                    Skills = skills
                };

                return Result.Success(options);
            }
            catch (Exception ex)
            {
                return Result.Failure<OptionsResponse>(
                    Error.Failure("Error", "There was an issue retrieving the options.")
                );
            }
        }
    }
}

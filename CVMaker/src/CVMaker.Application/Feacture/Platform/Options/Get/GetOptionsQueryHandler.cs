using CVMaker.Application.Abstractions.Data;
using CVMaker.Application.Abstractions.Messaging;
using CVMaker.Application.DTOs;
using CVMaker.SharedKernel;
using Microsoft.EntityFrameworkCore;

namespace CVMaker.Application.Features.Platform.Options.Get
{
    internal sealed class GetOptionsQueryHandler : IQueryHandler<GetOptionsQuery, OptionsResponse>
    {
        private readonly IApplicationDBContext _context;

        public GetOptionsQueryHandler(IApplicationDBContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<Result<OptionsResponse>> Handle(GetOptionsQuery request, CancellationToken
        cancellationToken)
        {
            try
            {
                var academicFields = await _context.AcademicFields
                    .AsNoTracking()
                    .Select(x => new OptionDTO { Id = x.ExternalID, Name = x.Description })
                    .ToListAsync(cancellationToken);

                var degrees = await _context.Degrees
                    .AsNoTracking()
                    .Select(x => new OptionDTO { Id = x.ExternalId, Name = x.Description })
                    .ToListAsync(cancellationToken);

                var jontitles = await _context.JobTitle
                    .AsNoTracking()
                    .Select(x => new OptionDTO { Id = x.ExternalId, Name = x.Description })
                    .ToListAsync(cancellationToken);

                var languages = await _context.Languages
                    .AsNoTracking()
                    .Select(x => new OptionDTO { Id = x.ExternalId, Name = x.description })
                    .ToListAsync(cancellationToken);

                var skills = await _context.Skill
                    .AsNoTracking()
                    .Select(x => new OptionDTO { Id = x.ExternalId, Name = x.Description })
                    .ToListAsync(cancellationToken);

                var Options = new OptionsResponse
                {
                    AcademicFields = academicFields,
                    Degrees = degrees,
                    Jobtitles = jontitles,
                    Languages = languages,
                    Skills = skills
                };
                return Result.Success(Options);
            }
            catch (Exception ex)
            {
                return Result.Failure<OptionsResponse>(
                    Error.Failure(
                        "Error",
                        "There was an issue retrieving the options."
                    )
                );    
            }
        }
    }
}
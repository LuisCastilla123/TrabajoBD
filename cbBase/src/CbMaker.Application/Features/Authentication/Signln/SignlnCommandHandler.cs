using CbMaker.Application.Abstractions.Data;
using CbMaker.Application.Abstractions.Messaging;
using CbMaker.Application.Abstractions.Authentication;
using CbMaker.Domain;
using CbMaker.SharedKernel;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Threading; 
using System.Threading.Tasks;
using MediatR;

namespace CbMaker.Application.Features.Authentication.SignIn
{
    internal sealed class SignInCommandHandler : ICommandHandler<SignInCommand, Unit>
    {
        private readonly IApplicationDbContext _context;
        private readonly IPasswordHasher _passwordHasher;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<SignInCommandHandler> _logger;

        public SignInCommandHandler(
            IApplicationDbContext context,
            IPasswordHasher passwordHasher,
            IUnitOfWork unitOfWork,
            ILogger<SignInCommandHandler> logger)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _passwordHasher = passwordHasher ?? throw new ArgumentNullException(nameof(passwordHasher));
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<Result<Unit>> Handle(SignInCommand request, CancellationToken cancellationToken)
        {
            try
            {
                await _unitOfWork.BeginTransactionAsync(cancellationToken);

                var userExists = await _context.Users
                    .AnyAsync(u => u.Email == request.Email, cancellationToken);

                if (userExists)
                {
                    return Result.Failure<Unit>(Error.Conflict("UserAlreadyExists", "The user already exists."));
                }

             var (passwordHashBytes, saltHashBytes) = _passwordHasher.Hash(request.Password);

var user = User.Create(
    request.UserName,
    request.Email,
    request.PhoneNumber,
    passwordHashBytes,
    saltHashBytes
);

                await _context.Users.AddAsync(user, cancellationToken);
                await _unitOfWork.SaveChangesAsync(cancellationToken);
                await _unitOfWork.CommitAsync(cancellationToken);

                _logger.LogInformation("User created successfully");

                return Result.Success(Unit.Value);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error creating user");
                await _unitOfWork.RollbackAsync(cancellationToken);
                return Result.Failure<Unit>(Error.Problem("UnhandledException", "An unexpected error occurred. Please try again later."));
            }
        }
    }
}

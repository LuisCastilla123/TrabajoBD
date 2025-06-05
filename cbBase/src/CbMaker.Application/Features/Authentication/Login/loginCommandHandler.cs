using CbMaker.Application.Abstractions.Authentication;
using CbMaker.Application.Abstractions.Data;
using CbMaker.Application.Abstractions.Messaging;
using CbMaker.SharedKernel;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;

namespace CbMaker.Application.Features.Authentication.Login
{
    internal sealed class LoginCommandHandler : ICommandHandler<LoginCommand, LoginResponse>
    {
        private readonly IJwtProvider _jwtProvider;
        private readonly IApplicationDbContext _context;
        private readonly IPasswordHasher _passwordHasher;
        private readonly ILogger<LoginCommandHandler> _logger;

        public LoginCommandHandler(
            IJwtProvider jwtProvider,
            IApplicationDbContext context,
            IPasswordHasher passwordHasher,
            ILogger<LoginCommandHandler> logger)
        {
            _jwtProvider = jwtProvider ?? throw new ArgumentNullException(nameof(jwtProvider));
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _passwordHasher = passwordHasher ?? throw new ArgumentNullException(nameof(passwordHasher));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<Result<LoginResponse>> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var user = await _context.Users
                    .FirstOrDefaultAsync(u => u.Email == request.Email, cancellationToken);

                if (user == null)
                {
                    return Result.Failure<LoginResponse>(
                        Error.Problem("InvalidCredentials", "Invalid email or password."));
                }

                // Convertir HashPassword (string) a byte[] si tu passwordHasher lo requiere
                var passwordHashBytes = Convert.FromBase64String(user.HashPassword);
                var saltBytes = user.HashSalting;

                if (!_passwordHasher.Verify(request.Password, passwordHashBytes, saltBytes))
                {
                    return Result.Failure<LoginResponse>(
                        Error.Problem("InvalidCredentials", "Invalid email or password."));
                }

                var token = _jwtProvider.GenerateToken(user);

                var response = new LoginResponse
                {
                    Username = user.Username,
                    Email = user.Email,
                    Token = token
                };

                return Result.Success(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while processing the login command.");
                return Result.Failure<LoginResponse>(
                    Error.Problem("UnhandledException", "An unexpected error occurred. Please try again later."));
            }
        }
    }
}

using CVMaker.Application.Abstractions;
using CVMaker.Application.Abstractions.Authentication;
using CVMaker.Application.Abstractions.Data;
using CVMaker.Application.Abstractions.Messaging;
using CVMaker.Domain.Entities;
using CVMaker.SharedKernel;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
namespace CVMaker.Application.Features.Authentication.SignIn

{

internal sealed class SignInCommandHandler : ICommandHandler<SignInCommand>
{

private readonly IApplicationDBContext context;

private readonly IPasswordHasher passwordHasher;

private readonly IUnitOfWork unitOfWork;

private readonly ILogger<SignInCommandHandler> logger;

public SignInCommandHandler(
    IApplicationDBContext context,
    IPasswordHasher passwordHasher,
    IUnitOfWork unitOfWork,
    ILogger<SignInCommandHandler> logger)
{
    this.context = context ?? throw new ArgumentNullException(nameof(context));
    this.passwordHasher = passwordHasher ?? throw new ArgumentNullException(nameof(passwordHasher));
    this.unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
    this.logger = logger ?? throw new ArgumentNullException(nameof(logger));
}

public async Task<Result> Handle(SignInCommand request, CancellationToken cancellationToken)
{
    try
    {
        await unitOfWork.BeginTransactionAsync(cancellationToken);

        var userExists = await context.Users
            .AnyAsync(u => u.Email == request.Email, cancellationToken);

        if (userExists)
        {
            return Result.Failure(Error.Conflict(
                "UserAlreadyExists",
                "The user already exists."));
        }

        (byte[] pwHash, byte[] saltHash) = passwordHasher.Hash(request.Password);

        var user = User.Create(
            request.UserName,
            request.Email,
            request.PhoneNumber,
            pwHash,
            saltHash
        );

        await context.Users.AddAsync(user, cancellationToken);

        await unitOfWork.SaveChangesAsync(cancellationToken);

        await unitOfWork.CommitAsync(cancellationToken);

        logger.LogInformation("User created successfully");

        return Result.Success();
    }
    catch (Exception ex)
    {
        logger.LogError(ex, "Error creating user");

        await unitOfWork.RollbackAsync(cancellationToken);

        return Result.Failure(Error.Problem(
            "UnhandledException",
            "An unexpected error occurred. Please try again later."));
    }
}

}

}

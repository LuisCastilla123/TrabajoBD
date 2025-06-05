using CbMaker.Application.Abstractions.Messaging;

namespace CbMaker.Application.Features.Authentication.Login
{
    public record LoginCommand(
        string Email,
        string Password
    ) : ICommand<LoginResponse>;
}


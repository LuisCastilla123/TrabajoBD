using CbMaker.Application.Abstractions.Messaging;
using CbMaker.SharedKernel;
using MediatR;


namespace CbMaker.Application.Features.Authentication.SignIn
{
    public record SignInCommand(
        string UserName,
        string Email,
        string PhoneNumber,
        string Password
    ) : ICommand<Unit>;
}


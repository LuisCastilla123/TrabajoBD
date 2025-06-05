using CVMaker.Application.Abstractions.Messaging;

namespace CVMaker.Application.Features.Authentication.Login

{

public sealed record LoginCommand(string Email, string Password) : ICommand<LoginResponse>;

}

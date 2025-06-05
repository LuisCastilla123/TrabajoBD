using CVMaker.Application.Abstractions.Messaging;

namespace CVMaker.Application.Features.Authentication.SignIn

{

public record SignInCommand(

string UserName,

string Email,

string PhoneNumber,

string Password

): ICommand;

}

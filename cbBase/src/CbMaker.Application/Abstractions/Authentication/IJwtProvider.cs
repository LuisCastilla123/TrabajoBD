using CbMaker.Domain;

namespace CbMaker.Application.Abstractions.Authentication;

public interface IJwtProvider

{
string GenerateToken(User user);
}


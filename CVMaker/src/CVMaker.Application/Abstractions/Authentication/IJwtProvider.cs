using CVMaker.Domain.Entities;

namespace CVMaker.Application.Abstractions.Authentication;

public interface IJwtProvider
{
    string GenerateToken(User user);
}
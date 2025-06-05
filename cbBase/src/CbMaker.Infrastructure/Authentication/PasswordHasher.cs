using CbMaker.Application.Abstractions.Authentication;
using CbMaker.Application.Common.Decorators;
using Microsoft.Extensions.DependencyInjection;
using System.Security.Cryptography;

namespace CbMaker.Infrastructure.Authentication
{
    [Injectable(ServiceLifetime.Singleton)]
    internal sealed class PasswordHasher : IPasswordHasher
    {
        private const int SaltSize = 16;
        private const int HashSize = 32;
        private const int Iterations = 500000;
        private static readonly HashAlgorithmName Algorithm = HashAlgorithmName.SHA512;

        public bool Verify(string password, byte[] passwordHash, byte[] saltHash)
        {
            byte[] inputHash = Rfc2898DeriveBytes.Pbkdf2(password, saltHash, Iterations, Algorithm, HashSize);
            return CryptographicOperations.FixedTimeEquals(passwordHash, inputHash);
        }

        public (byte[] passwordHash, byte[] saltHash) Hash(string password)
        {
            byte[] salt = RandomNumberGenerator.GetBytes(SaltSize);
            byte[] hash = Rfc2898DeriveBytes.Pbkdf2(password, salt, Iterations, Algorithm, HashSize);
            return (hash, salt);
        }
    }
}

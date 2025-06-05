using CVMaker.Application.Abstractions.Authentication;
using Microsoft.Extensions.DependencyInjection;
using System.Security.Cryptography;

namespace CVMaker.Infrastructure.Authentication
{
    [Injectable(ServiceLifetime.Singleton)]
    internal sealed class PasswordHasher : IPasswordHasher
    {
        private const int SaltSize = 16;
        private const int HashSize = 32;
        private const int Iterations = 500000;

        private static readonly HashAlgorithmName Algorithm = HashAlgorithmName.SHA512;

        public bool Verify(string password, byte[] pwsHashBinary, byte[] sltHashBinary)
        {
            byte[] inputHash = Rfc2898DeriveBytes.Pbkdf2(password, sltHashBinary, Iterations, Algorithm, HashSize);
            return CryptographicOperations.FixedTimeEquals(pwsHashBinary, inputHash);
        }

        public (byte[] pwsHash, byte[] sltHash) Hash(string password)
        {
            byte[] salt = RandomNumberGenerator.GetBytes(SaltSize);
            byte[] hash = Rfc2898DeriveBytes.Pbkdf2(password, salt, Iterations, Algorithm, HashSize);

            return (hash, salt);
        }
    }
}
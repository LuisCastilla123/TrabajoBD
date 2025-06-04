namespace CVMaker.Application.Abstractions.Authentication;

    public interface IPasswordHasher
{
    (byte[] pwsHash, byte[] sltHash) Hash(string password);

    bool Verify(string password, byte[] pwsHashBinary, byte[] slthasBinary);
    }

namespace CbMaker.Application.Abstractions.Authentication
{
    public interface IPasswordHasher
    {
    
        (byte[] passwordHash, byte[] saltHash) Hash(string password);

        bool Verify(string password, byte[] passwordHash, byte[] saltHash);
    }
}

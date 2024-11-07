namespace Ultimus.Application.Contracts.Infrastructure.Encryption
{
    public interface IEncryptionService
    {
        string Encrypt(string data);
    }
}

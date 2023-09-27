namespace Pavolle.Security.Symmetric
{
    public interface ISymmetric
    {
        string Encrypt(string message, string password);
        string Decrypt(string encryptedMessage, string password);
    }
}

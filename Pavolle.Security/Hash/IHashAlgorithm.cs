namespace Pavolle.Security.Hash
{
    internal interface IHashAlgorithm
    {
        byte[] ExecuteHashAlgorithm(byte[] plaintext);
        string ExecuteHashAlgorithm(string plaintext);
        byte[] ExecuteHMACHashAlgorithm(byte[] plaintext, byte[] password);
        byte[] ExecuteHMACHashAlgorithm(byte[] plaintext, string password);
        string ExecuteHMACHashAlgorithm(string plaintext, string password);
    }
}

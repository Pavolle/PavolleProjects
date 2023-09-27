using System.Security.Cryptography;

namespace Pavolle.Security.Hash
{
    public class SHA384HashAlgorithm : AbstractHashAlgorithm
    {
        public override byte[] ExecuteHashAlgorithm(byte[] plaintext)
        {
            byte[] result;
            using (var provider = new SHA384CryptoServiceProvider())
            {
                result = provider.ComputeHash(plaintext);
            }
            return result;
        }

        public override byte[] ExecuteHMACHashAlgorithm(byte[] plaintext, byte[] password)
        {
            byte[] result;
            using (var provider = new HMACSHA384(password))
            {
                result = provider.ComputeHash(plaintext);
            }
            return result;
        }
    }
}

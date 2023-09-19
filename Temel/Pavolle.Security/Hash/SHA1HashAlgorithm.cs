
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Pavolle.Security.Hash
{
    public class SHA1HashAlgorithm : AHashAlgorithm
    {
        public override byte[] ExecuteHashAlgorithm(byte[] plaintext)
        {
            byte[] result;
            using (var sha1provider = new SHA1CryptoServiceProvider())
            {
                result = sha1provider.ComputeHash(plaintext);
            }
            return result;
        }
        
        public override byte[] ExecuteHMACHashAlgorithm(byte[] plaintext, byte[] password)
        {
            byte[] result;
            using (var hmacsha1provider = new HMACSHA1(password))
            {
                result = hmacsha1provider.ComputeHash(plaintext);
            }
            return result;
        }
    }
}

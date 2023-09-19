using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Pavolle.Security.Hash
{
    public class SHA256HashAlgorithm:AHashAlgorithm
    {
        public override byte[] ExecuteHashAlgorithm(byte[] plaintext)
        {
            byte[] result;
            using (var sha256provider = new SHA256CryptoServiceProvider())
            {
                result = sha256provider.ComputeHash(plaintext);
            }
            return result;
        }
        public override byte[] ExecuteHMACHashAlgorithm(byte[] plaintext, byte[] password)
        {
            byte[] result;
            using (var hmacsha256provider = new HMACSHA256(password))
            {
                result = hmacsha256provider.ComputeHash(plaintext);
            }
            return result;
        }
    }
}

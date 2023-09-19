using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Pavolle.Security.Hash
{
    public class SHA512HashAlgorithm:AHashAlgorithm
    {
        public override byte[] ExecuteHashAlgorithm(byte[] plaintext)
        {
            byte[] result;
            using (var sha512provider = new SHA512CryptoServiceProvider())
            {
                result = sha512provider.ComputeHash(plaintext);
            }
            return result;
        }
        public override byte[] ExecuteHMACHashAlgorithm(byte[] plaintext, byte[] password)
        {
            byte[] result;
            using (var hmacsha512provider = new HMACSHA512(password))
            {
                result = hmacsha512provider.ComputeHash(plaintext);
            }
            return result;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Pavolle.Security.Hash
{
    public class SHA384HashAlgorithm:AHashAlgorithm
    {
        public override byte[] ExecuteHashAlgorithm(byte[] plaintext)
        {
            byte[] result;
            using (var sha384provider = new SHA384CryptoServiceProvider())
            {
                result = sha384provider.ComputeHash(plaintext);
            }
            return result;
        }
        public override byte[] ExecuteHMACHashAlgorithm(byte[] plaintext, byte[] password)
        {
            byte[] result;
            using (var hmacsha384provider = new HMACSHA384(password))
            {
                result = hmacsha384provider.ComputeHash(plaintext);
            }
            return result;
        }
    }
}

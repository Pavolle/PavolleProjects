
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Pavolle.Security.Hash
{
    public abstract class AHashAlgorithm : IHashAlgorithm
    {
        public string ExecuteHashAlgorithm(string plaintext)
        {
            return SecurityHelper.ConvertOperation.ByteToString
                (ExecuteHashAlgorithm(SecurityHelper.ConvertOperation.StringToByte(plaintext)));
        }

        public virtual byte[] ExecuteHashAlgorithm(byte[] plaintext)
        {
            return null;
        }

        public string ExecuteHMACHashAlgorithm(string plaintext, string password)
        {
            return SecurityHelper.ConvertOperation.ByteToString(
                ExecuteHMACHashAlgorithm(SecurityHelper.ConvertOperation.StringToByte(plaintext), SecurityHelper.ConvertOperation.StringToByte(password)));
        }

        public byte[] ExecuteHMACHashAlgorithm(byte[] plaintext, string password)
        {
            return ExecuteHMACHashAlgorithm(plaintext, SecurityHelper.ConvertOperation.StringToByte(password));
        }

        public virtual byte[] ExecuteHMACHashAlgorithm(byte[] plaintext, byte[] password)
        {
            return null;
        }
    }
}

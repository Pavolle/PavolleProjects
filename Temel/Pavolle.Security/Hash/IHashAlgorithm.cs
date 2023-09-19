using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

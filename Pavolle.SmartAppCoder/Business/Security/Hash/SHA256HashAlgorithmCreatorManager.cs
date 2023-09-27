using Pavolle.SmartAppCoder.Common.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pavolle.SmartAppCoder.Business.Security.Hash
{
    internal class SHA256HashAlgorithmCreatorManager : Singleton<SHA256HashAlgorithmCreatorManager>
    {
        private SHA256HashAlgorithmCreatorManager() { }

        public bool Create(string projectPath, string organizationName)
        {
            string classString = "";
            classString += "using System.Security.Cryptography;" + Environment.NewLine;
            classString += "" + Environment.NewLine;
            classString += "namespace " + organizationName + ".Security.Hash" + Environment.NewLine;
            classString += "{" + Environment.NewLine;
            classString += "    public class SHA256HashAlgorithm : AbstractHashAlgorithm" + Environment.NewLine;
            classString += "    {" + Environment.NewLine;
            classString += "        public override byte[] ExecuteHashAlgorithm(byte[] plaintext)" + Environment.NewLine;
            classString += "        {" + Environment.NewLine;
            classString += "            byte[] result;" + Environment.NewLine;
            classString += "            using (var provider = new SHA256CryptoServiceProvider())" + Environment.NewLine;
            classString += "            {" + Environment.NewLine;
            classString += "                result = provider.ComputeHash(plaintext);" + Environment.NewLine;
            classString += "            }" + Environment.NewLine;
            classString += "            return result;" + Environment.NewLine;
            classString += "        }" + Environment.NewLine;
            classString += "" + Environment.NewLine;
            classString += "        public override byte[] ExecuteHMACHashAlgorithm(byte[] plaintext, byte[] password)" + Environment.NewLine;
            classString += "        {" + Environment.NewLine;
            classString += "            byte[] result;" + Environment.NewLine;
            classString += "            using (var provider = new HMACSHA256(password))" + Environment.NewLine;
            classString += "            {" + Environment.NewLine;
            classString += "                result = provider.ComputeHash(plaintext);" + Environment.NewLine;
            classString += "            }" + Environment.NewLine;
            classString += "            return result;" + Environment.NewLine;
            classString += "        }" + Environment.NewLine;
            classString += "    }" + Environment.NewLine;
            classString += "}" + Environment.NewLine;
            return FileHelperManager.Instance.WriteFile(projectPath + "\\" + organizationName + ".Security", "Hash", "SHA256HashAlgorithm.cs", classString);

        }
    }
}

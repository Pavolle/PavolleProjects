using Pavolle.SmartAppCoder.Common.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pavolle.SmartAppCoder.Business.Security.Hash
{
    internal class IHashAlgorithmCreatorManager : Singleton<IHashAlgorithmCreatorManager>
    {
        private IHashAlgorithmCreatorManager() { }

        public bool Create(string projectPath, string organizationName)
        {
            string classString = "";
            classString += "namespace " + organizationName + ".Security.Hash" + Environment.NewLine;
            classString += "{" + Environment.NewLine;
            classString += "    internal interface IHashAlgorithm" + Environment.NewLine;
            classString += "    {" + Environment.NewLine;
            classString += "        byte[] ExecuteHashAlgorithm(byte[] plaintext);" + Environment.NewLine;
            classString += "        string ExecuteHashAlgorithm(string plaintext);" + Environment.NewLine;
            classString += "        byte[] ExecuteHMACHashAlgorithm(byte[] plaintext, byte[] password);" + Environment.NewLine;
            classString += "        byte[] ExecuteHMACHashAlgorithm(byte[] plaintext, string password);" + Environment.NewLine;
            classString += "        string ExecuteHMACHashAlgorithm(string plaintext, string password);" + Environment.NewLine;
            classString += "    }" + Environment.NewLine;
            classString += "}" + Environment.NewLine;
            return FileHelperManager.Instance.WriteFile(projectPath + "\\" + organizationName + ".Security", "Hash", "IHashAlgorithm.cs", classString);

        }
    }
}

using Pavolle.SmartAppCoder.Business.Core.ViewModels.Model;
using Pavolle.SmartAppCoder.Common.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pavolle.SmartAppCoder.Business.Security.Hash
{
    internal class AbstractHashAlgorithmCreatorManager : Singleton<AbstractHashAlgorithmCreatorManager>
    {
        private AbstractHashAlgorithmCreatorManager() { }

        public bool Create(string projectPath, string organizationName)
        {
            string classString = "";
            classString += "namespace " + organizationName + ".Security.Hash" + Environment.NewLine;
            classString += "{" + Environment.NewLine;
            classString += "    public abstract class AbstractHashAlgorithm : IHashAlgorithm" + Environment.NewLine;
            classString += "    {" + Environment.NewLine;
            classString += "        public string ExecuteHashAlgorithm(string plaintext)" + Environment.NewLine;
            classString += "        {" + Environment.NewLine;
            classString += "            return SecurityHelper.ConvertOperation.ByteToString(ExecuteHashAlgorithm(SecurityHelper.ConvertOperation.StringToByte(plaintext)));" + Environment.NewLine;
            classString += "        }" + Environment.NewLine;
            classString += "" + Environment.NewLine;
            classString += "        public virtual byte[] ExecuteHashAlgorithm(byte[] plaintext)" + Environment.NewLine;
            classString += "        {" + Environment.NewLine;
            classString += "            return null;" + Environment.NewLine;
            classString += "        }" + Environment.NewLine;
            classString += "" + Environment.NewLine;
            classString += "        public string ExecuteHMACHashAlgorithm(string plaintext, string password)" + Environment.NewLine;
            classString += "        {" + Environment.NewLine;
            classString += "            return SecurityHelper.ConvertOperation.ByteToString(ExecuteHMACHashAlgorithm(SecurityHelper.ConvertOperation.StringToByte(plaintext), SecurityHelper.ConvertOperation.StringToByte(password)));" + Environment.NewLine;
            classString += "        }" + Environment.NewLine;
            classString += "" + Environment.NewLine;
            classString += "        public byte[] ExecuteHMACHashAlgorithm(byte[] plaintext, string password)" + Environment.NewLine;
            classString += "        {" + Environment.NewLine;
            classString += "            return ExecuteHMACHashAlgorithm(plaintext, SecurityHelper.ConvertOperation.StringToByte(password));" + Environment.NewLine;
            classString += "        }" + Environment.NewLine;
            classString += "" + Environment.NewLine;
            classString += "        public virtual byte[] ExecuteHMACHashAlgorithm(byte[] plaintext, byte[] password)" + Environment.NewLine;
            classString += "        {" + Environment.NewLine;
            classString += "            return null;" + Environment.NewLine;
            classString += "        }" + Environment.NewLine;
            classString += "    }" + Environment.NewLine;
            classString += "}" + Environment.NewLine;
            return FileHelperManager.Instance.WriteFile(projectPath + "\\" + organizationName + ".Security", "Hash", "AbstractHashAlgorithm.cs", classString);

        }
    }
}

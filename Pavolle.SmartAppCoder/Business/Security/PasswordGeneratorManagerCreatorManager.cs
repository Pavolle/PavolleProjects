using Pavolle.SmartAppCoder.Common.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pavolle.SmartAppCoder.Business.Security
{
    internal class PasswordGeneratorManagerCreatorManager : Singleton<PasswordGeneratorManagerCreatorManager>
    {
        private PasswordGeneratorManagerCreatorManager() { }

        public bool Create(string projectPath, string organizationName)
        {
            string classString = "";
            classString += "using " + organizationName + ".Core.Utils;" + Environment.NewLine;
            classString += "using " + organizationName + ".Security.Symmetric;" + Environment.NewLine;
            classString += "" + Environment.NewLine;
            classString += "namespace " + organizationName + ".Security" + Environment.NewLine;
            classString += "{" + Environment.NewLine;
            classString += "    public class PasswordGeneratorManager : Singleton<PasswordGeneratorManager>" + Environment.NewLine;
            classString += "    {" + Environment.NewLine;
            classString += "        string _key = \"pl@gHa23\";" + Environment.NewLine;
            classString += "" + Environment.NewLine;
            classString += "        private PasswordGeneratorManager() { }" + Environment.NewLine;
            classString += "" + Environment.NewLine;
            classString += "        public string GeneratePassword(string key)" + Environment.NewLine;
            classString += "        {" + Environment.NewLine;
            classString += "            if (string.IsNullOrWhiteSpace(key)) return \"\";" + Environment.NewLine;
            classString += "            var aesAlgorithm = new AESAlgorithm();" + Environment.NewLine;
            classString += "            var aesResult = aesAlgorithm.Encrypt(key, _key);" + Environment.NewLine;
            classString += "            return SecurityHelperManager.Instance.GetEncryptedPassword(aesResult, key).Substring(13, 24);" + Environment.NewLine;
            classString += "        }" + Environment.NewLine;
            classString += "    }" + Environment.NewLine;
            classString += "}" + Environment.NewLine;
            return FileHelperManager.Instance.WriteFile(projectPath + "\\" + organizationName + ".Security", "", "PasswordGeneratorManager.cs", classString);

        }
    }
}

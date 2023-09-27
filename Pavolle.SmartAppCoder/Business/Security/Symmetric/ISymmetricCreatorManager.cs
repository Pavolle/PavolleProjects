using Pavolle.SmartAppCoder.Common.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pavolle.SmartAppCoder.Business.Security.Symmetric
{
    internal class ISymmetricCreatorManager : Singleton<ISymmetricCreatorManager>
    {
        private ISymmetricCreatorManager() { }

        public bool Create(string projectPath, string organizationName)
        {
            string classString = "";
            classString += "namespace " + organizationName + ".Security.Symmetric" + Environment.NewLine;
            classString += "{" + Environment.NewLine;
            classString += "    public interface ISymmetric" + Environment.NewLine;
            classString += "    {" + Environment.NewLine;
            classString += "        string Encrypt(string message, string password);" + Environment.NewLine;
            classString += "        string Decrypt(string encryptedMessage, string password);" + Environment.NewLine;
            classString += "    }" + Environment.NewLine;
            classString += "}" + Environment.NewLine;
            return FileHelperManager.Instance.WriteFile(projectPath + "\\" + organizationName + ".Security", "Symmetric", "ISymmetric.cs", classString);

        }
    }
}

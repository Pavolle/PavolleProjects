using Pavolle.SmartAppCoder.Common.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pavolle.SmartAppCoder.Business.Security.Hash
{
    internal class SHA384HashAlgorithmCreatorManager : Singleton<SHA384HashAlgorithmCreatorManager>
    {
        private SHA384HashAlgorithmCreatorManager() { }

        public bool Create(string projectPath, string organizationName)
        {
            string classString = "";
            classString += "" + Environment.NewLine;
            return FileHelperManager.Instance.WriteFile(projectPath + "\\" + organizationName + ".Security", "Hash", "LanguageModel.cs", classString);

        }
    }
}

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
            classString += "" + Environment.NewLine;
            return FileHelperManager.Instance.WriteFile(projectPath + "\\" + organizationName + ".Security", "", "LanguageModel.cs", classString);

        }
    }
}

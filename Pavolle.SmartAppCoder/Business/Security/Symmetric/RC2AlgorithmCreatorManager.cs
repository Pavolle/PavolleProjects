using Pavolle.SmartAppCoder.Common.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pavolle.SmartAppCoder.Business.Security.Symmetric
{
    internal class RC2AlgorithmCreatorManager : Singleton<RC2AlgorithmCreatorManager>
    {
        private RC2AlgorithmCreatorManager() { }

        public bool Create(string projectPath, string organizationName)
        {
            string classString = "";
            classString += "" + Environment.NewLine;
            return FileHelperManager.Instance.WriteFile(projectPath + "\\" + organizationName + ".Security", "Symmetric", "LanguageModel.cs", classString);

        }
    }
}

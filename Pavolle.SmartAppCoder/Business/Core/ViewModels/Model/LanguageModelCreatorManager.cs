using Pavolle.SmartAppCoder.Common.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pavolle.SmartAppCoder.Business.Core.ViewModels.Model
{
    public class LanguageModelCreatorManager : Singleton<LanguageModelCreatorManager>
    {
        private LanguageModelCreatorManager() { }

        public bool Create(string projectPath, string organizationName)
        {
            string classString = "";
            classString += "using " + organizationName + ".Core.Enums;" + Environment.NewLine;
            classString += "" + Environment.NewLine;
            classString += "namespace " + organizationName + ".Core.ViewModels.Model" + Environment.NewLine;
            classString += "{" + Environment.NewLine;
            classString += "    public class LanguageModel" + Environment.NewLine;
            classString += "    {" + Environment.NewLine;
            classString += "        public ELanguage Code { get; set; }" + Environment.NewLine;
            classString += "        public string Name { get; set; }" + Environment.NewLine;
            classString += "    }" + Environment.NewLine;
            classString += "}" + Environment.NewLine;
            return FileHelperManager.Instance.WriteFile(projectPath + "\\" + organizationName + ".Core", "ViewModels\\Model", "LanguageModel.cs", classString);

        }
    }
}

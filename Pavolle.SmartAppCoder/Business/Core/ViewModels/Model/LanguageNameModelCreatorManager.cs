using Pavolle.SmartAppCoder.Common.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pavolle.SmartAppCoder.Business.Core.ViewModels.Model
{
    public class LanguageNameModelCreatorManager : Singleton<LanguageNameModelCreatorManager>
    {
        private LanguageNameModelCreatorManager() { }

        public bool Create(string projectPath, string organizationName)
        {
            string classString = "";
            classString += "using "+ organizationName + ".Core.Enums;" + Environment.NewLine;
            classString += "" + Environment.NewLine;
            classString += "namespace "+ organizationName + ".Core.ViewModels.Model" + Environment.NewLine;
            classString += "{" + Environment.NewLine;
            classString += "    public class LanguageNameModel" + Environment.NewLine;
            classString += "    {" + Environment.NewLine;
            classString += "        public ELanguage Language { get; set; }" + Environment.NewLine;
            classString += "        public string English { get; set; }" + Environment.NewLine;
            classString += "        public string German { get; set; }" + Environment.NewLine;
            classString += "        public string Spanish { get; set; }" + Environment.NewLine;
            classString += "        public string French { get; set; }" + Environment.NewLine;
            classString += "        public string Russian { get; set; }" + Environment.NewLine;
            classString += "        public string Turkish { get; set; }" + Environment.NewLine;
            classString += "        public string Azerbaijani { get; set; }" + Environment.NewLine;
            classString += "    }" + Environment.NewLine;
            classString += "}" + Environment.NewLine;
            return FileHelperManager.Instance.WriteFile(projectPath + "\\" + organizationName + ".Core", "ViewModels\\Model", "LanguageNameModel.cs", classString);

        }
    }
}

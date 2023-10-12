using Pavolle.SmartAppCoder.Common.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pavolle.SmartAppCoder.Business.Projects.ProjectBusiness
{
    public class ValidationManagerCreatorManager : Singleton<ValidationManagerCreatorManager>
    {
        private ValidationManagerCreatorManager() { }

        public bool Create(string organizationName, string projectName, string projectPath, string language)
        {
            if (language == null) language = "en, tr";
            string[] _languages = language.Split(',');
            string projectNameRoot = organizationName + "." + projectName;
            string classString = "";
            classString += "using DevExpress.Xpo;" + Environment.NewLine;
            classString += "using log4net;" + Environment.NewLine;
            classString += "using " + organizationName + ".Core.Enums;" + Environment.NewLine;
            classString += "using " + organizationName + ".Core.Utils;" + Environment.NewLine;
            classString += "using " + projectNameRoot + ".Common.Enums;" + Environment.NewLine;
            classString += "using " + projectNameRoot + ".DbModels;" + Environment.NewLine;
            classString += "using " + projectNameRoot + ".DbModels.Entities;" + Environment.NewLine;
            classString += "using " + projectNameRoot + ".DbModels.Manager;" + Environment.NewLine;
            classString += "using " + projectNameRoot + ".ViewModels.Criteria;" + Environment.NewLine;
            classString += "using " + projectNameRoot + ".ViewModels.Model;" + Environment.NewLine;
            classString += "using " + projectNameRoot + ".ViewModels.Request;" + Environment.NewLine;
            classString += "using " + projectNameRoot + ".ViewModels.Response;" + Environment.NewLine;
            classString += "using " + projectNameRoot + ".ViewModels.ViewData;" + Environment.NewLine;
            classString += "using System.Linq;" + Environment.NewLine;
            classString += "using System;" + Environment.NewLine;
            classString += "using System.Collections.Concurrent;" + Environment.NewLine;
            classString += "using System.Collections.Generic;" + Environment.NewLine;
            classString += "using System.Text;" + Environment.NewLine;
            classString += "using System.Threading.Tasks;" + Environment.NewLine;
            classString += "" + Environment.NewLine;
            classString += "namespace " + projectNameRoot + ".Business.Manager" + Environment.NewLine;
            classString += "{" + Environment.NewLine;
            classString += "    public class ValidationManager:Singleton<ValidationManager>" + Environment.NewLine;
            classString += "    {" + Environment.NewLine;
            classString += "        static readonly ILog _log = LogManager.GetLogger(typeof(ValidationManager));" + Environment.NewLine;
            classString += "        private ValidationManager() " + Environment.NewLine;
            classString += "        {" + Environment.NewLine;
            classString += "            _log.Debug(\"Initialize \"+nameof(ValidationManager));" + Environment.NewLine;
            classString += "        }" + Environment.NewLine;
            classString += "" + Environment.NewLine;
            classString += "        public string? CheckString(string? text, bool nullable, int minLength, int maxLength, bool xssControl, EMessageCode messageCode, ELanguage language)" + Environment.NewLine;
            classString += "        {" + Environment.NewLine;
            classString += "            try" + Environment.NewLine;
            classString += "            {" + Environment.NewLine;
            classString += "                string? response = null;" + Environment.NewLine;
            classString += "" + Environment.NewLine;
            classString += "" + Environment.NewLine;
            classString += "" + Environment.NewLine;
            classString += "" + Environment.NewLine;
            classString += "" + Environment.NewLine;
            classString += "" + Environment.NewLine;
            classString += "" + Environment.NewLine;
            classString += "" + Environment.NewLine;
            classString += "" + Environment.NewLine;
            classString += "" + Environment.NewLine;
            classString += "" + Environment.NewLine;
            classString += "" + Environment.NewLine;
            classString += "" + Environment.NewLine;
            classString += "" + Environment.NewLine;
            classString += "" + Environment.NewLine;
            classString += "" + Environment.NewLine;
            classString += "" + Environment.NewLine;
            classString += "" + Environment.NewLine;
            classString += "" + Environment.NewLine;
            classString += "" + Environment.NewLine;
            classString += "" + Environment.NewLine;
            classString += "" + Environment.NewLine;
            classString += "" + Environment.NewLine;
            classString += "" + Environment.NewLine;
            classString += "" + Environment.NewLine;
            classString += "" + Environment.NewLine;
            classString += "" + Environment.NewLine;
            classString += "" + Environment.NewLine;
            classString += "" + Environment.NewLine;
            classString += "" + Environment.NewLine;
            classString += "" + Environment.NewLine;
            classString += "" + Environment.NewLine;
            classString += "" + Environment.NewLine;
            classString += "" + Environment.NewLine;
            classString += "" + Environment.NewLine;
            classString += "" + Environment.NewLine;


            return FileHelperManager.Instance.WriteFile(projectPath, projectNameRoot + ".Business/Manager", "ValidationManager.cs", classString);
        }
    }
}

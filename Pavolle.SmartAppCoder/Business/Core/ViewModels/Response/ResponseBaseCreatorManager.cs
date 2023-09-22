using Pavolle.SmartAppCoder.Common.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pavolle.SmartAppCoder.Business.Core.ViewModels.Response
{
    internal class ResponseBaseCreatorManager : Singleton<ResponseBaseCreatorManager>
    {
        private ResponseBaseCreatorManager() { }

        public bool Create(string projectPath, string organizationName)
        {

            string classString = "";
            classString += "namespace " + organizationName + ".Core.ViewModels.Response" + Environment.NewLine;
            classString += "{" + Environment.NewLine;
            classString += "    public class ResponseBase" + Environment.NewLine;
            classString += "    {" + Environment.NewLine;
            classString += "        public bool Success { get; set; } = true;" + Environment.NewLine;
            classString += "" + Environment.NewLine;
            classString += "        private string? _errorMessage;" + Environment.NewLine;
            classString += "        public string? ErrorMessage" + Environment.NewLine;
            classString += "        {" + Environment.NewLine;
            classString += "            get { return _errorMessage; }" + Environment.NewLine;
            classString += "            set" + Environment.NewLine;
            classString += "            {" + Environment.NewLine;
            classString += "                _errorMessage = value;" + Environment.NewLine;
            classString += "                if (!string.IsNullOrEmpty(_errorMessage))" + Environment.NewLine;
            classString += "                {" + Environment.NewLine;
            classString += "                    Success = false;" + Environment.NewLine;
            classString += "                }" + Environment.NewLine;
            classString += "            }" + Environment.NewLine;
            classString += "        }" + Environment.NewLine;
            classString += "" + Environment.NewLine;
            classString += "        public string? SuccessMessage { get; set; }" + Environment.NewLine;
            classString += "        public string? InfoMessage { get; set; }" + Environment.NewLine;
            classString += "        public string? WarningMessage { get; set; }" + Environment.NewLine;
            classString += "    }" + Environment.NewLine;
            classString += "}" + Environment.NewLine;
            return FileHelperManager.Instance.WriteFile(projectPath + "\\" + organizationName + ".Core", "ViewModels\\Response", "ResponseBase.cs", classString);

        }
    }
}

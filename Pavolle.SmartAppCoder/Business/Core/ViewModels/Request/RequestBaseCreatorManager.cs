using Pavolle.SmartAppCoder.Common.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pavolle.SmartAppCoder.Business.Core.ViewModels.Request
{
    internal class RequestBaseCreatorManager : Singleton<RequestBaseCreatorManager>
    {
        private RequestBaseCreatorManager() { }

        public bool Create(string projectPath, string organizationName)
        {
            string classString = "";
            classString += "using "+organizationName+".Core.Enums;" + Environment.NewLine; 
            classString += "" + Environment.NewLine;
            classString += "namespace " + organizationName + ".Core.ViewModels.Request" + Environment.NewLine;
            classString += "{" + Environment.NewLine;
            classString += "    public class RequestBase : IRequest" + Environment.NewLine;
            classString += "    {" + Environment.NewLine;
            classString += "        public ELanguage? Language { get; set; }" + Environment.NewLine;
            classString += "        public string RequestIp { get; set; }" + Environment.NewLine;
            classString += "    }" + Environment.NewLine;
            classString += "}" + Environment.NewLine;
            return FileHelperManager.Instance.WriteFile(projectPath + "\\" + organizationName + ".Core", "ViewModels\\Request", "RequestBase.cs", classString);

        }
    }
}

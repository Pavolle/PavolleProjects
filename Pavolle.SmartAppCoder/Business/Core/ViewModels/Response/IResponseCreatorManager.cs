using Pavolle.SmartAppCoder.Common.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pavolle.SmartAppCoder.Business.Core.ViewModels.Response
{
    internal class IResponseCreatorManager : Singleton<IResponseCreatorManager>
    {
        private IResponseCreatorManager() { }

        public bool Create(string projectPath, string organizationName)
        {
            string classString = "";
            classString += "namespace " + organizationName + ".Core.ViewModels.Response" + Environment.NewLine;
            classString += "{" + Environment.NewLine;
            classString += "    public interface IResponse" + Environment.NewLine;
            classString += "    {" + Environment.NewLine;
            classString += "    }" + Environment.NewLine;
            classString += "}" + Environment.NewLine;
            return FileHelperManager.Instance.WriteFile(projectPath + "\\" + organizationName + ".Core", "ViewModels\\Response", "IResponse.cs", classString);

        }
    }
}

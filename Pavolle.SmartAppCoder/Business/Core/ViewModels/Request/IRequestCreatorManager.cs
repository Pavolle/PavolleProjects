using Pavolle.SmartAppCoder.Common.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pavolle.SmartAppCoder.Business.Core.ViewModels.Request
{
    internal class IRequestCreatorManager : Singleton<IRequestCreatorManager>
    {
        private IRequestCreatorManager() { }

        public bool Create(string projectPath, string organizationName)
        {
            string classString = "";
            classString += "namespace " + organizationName + ".Core.ViewModels.Request" + Environment.NewLine;
            classString += "{" + Environment.NewLine;
            classString += "    public interface IRequest" + Environment.NewLine;
            classString += "    {" + Environment.NewLine;
            classString += "    }" + Environment.NewLine;
            classString += "}" + Environment.NewLine;
            return FileHelperManager.Instance.WriteFile(projectPath + "\\" + organizationName + ".Core", "ViewModels\\Request", "IRequest.cs", classString);

        }
    }
}

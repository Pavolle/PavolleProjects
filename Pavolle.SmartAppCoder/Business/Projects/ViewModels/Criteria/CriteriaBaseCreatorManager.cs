using Pavolle.SmartAppCoder.Common.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pavolle.SmartAppCoder.Business.Projects.ViewModels.Criteria
{
    public class CriteriaBaseCreatorManager : Singleton<CriteriaBaseCreatorManager>
    {
        private CriteriaBaseCreatorManager() { }
        public bool Write(string companyName, string projectName, string projectPath)
        {
            string projectNameRoot=companyName+"."+projectName;
            string criteriaBaseClass = "";
            criteriaBaseClass += "using " + projectNameRoot + ".Common.Enums;" + Environment.NewLine;
            criteriaBaseClass += "using " + companyName + ".Core.Enums;" + Environment.NewLine;
            criteriaBaseClass += "";
            criteriaBaseClass += "namespace " + projectNameRoot + ".ViewModels.Criteria" + Environment.NewLine;
            criteriaBaseClass += "{" + Environment.NewLine;
            criteriaBaseClass += "    public class " + projectName + "CriteriaBase:" + projectName + "RequestBase" + Environment.NewLine;
            criteriaBaseClass += "    {" + Environment.NewLine;
            criteriaBaseClass += "    }" + Environment.NewLine;
            criteriaBaseClass += "}" + Environment.NewLine;

            return FileHelperManager.Instance.WriteFile(projectPath, projectNameRoot + ".ViewModels/Criteria", projectName + "CriteriaBase.cs", criteriaBaseClass);
        }
    }
}

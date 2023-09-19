using Pavolle.Core.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pavolle.CrudOperationHelper.Business.ViewModels.Criteria
{
    public class CriteriaBaseCreatorManager : Singleton<CriteriaBaseCreatorManager>, ICreatorManager
    {
        private CriteriaBaseCreatorManager() { }
        public bool Write(string companyName, string projectName, string projectPath)
        {
            string projectNameRoot=companyName+"."+projectName;
            string criteriaBaseClass = "";
            criteriaBaseClass += "using " + projectNameRoot + "." + AppConsts.ViewModelsProjectName + "." + AppConsts.ViewModelsRequestFolderName + ";" + Environment.NewLine;
            criteriaBaseClass += "";
            criteriaBaseClass += "namespace " + projectNameRoot + "." + AppConsts.ViewModelsProjectName + "." + AppConsts.ViewModelsCriteriaFolderName + Environment.NewLine;
            criteriaBaseClass += "{" + Environment.NewLine;
            criteriaBaseClass += "    public class " + projectName + "CriteriaBase:" + projectName + "RequestBase" + Environment.NewLine;
            criteriaBaseClass += "    {" + Environment.NewLine;
            criteriaBaseClass += "    }" + Environment.NewLine;
            criteriaBaseClass += "}" + Environment.NewLine;

            return FileHelperManager.Instance.WriteFile(projectPath, projectNameRoot + "." + AppConsts.ViewModelsProjectName + "/" + AppConsts.ViewModelsCriteriaFolderName, projectName + AppConsts.ViewModelsCriteriaBaseClassName + ".cs", criteriaBaseClass);
        }
    }
}

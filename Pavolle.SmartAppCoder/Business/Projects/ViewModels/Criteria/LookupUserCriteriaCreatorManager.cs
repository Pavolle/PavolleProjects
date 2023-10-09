using Pavolle.SmartAppCoder.Common.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pavolle.SmartAppCoder.Business.Projects.ViewModels.Criteria
{
    internal class LookupUserCriteriaCreatorManager : Singleton<LookupUserCriteriaCreatorManager>
    {
        private LookupUserCriteriaCreatorManager() { }
        public bool Write(string companyName, string projectName, string projectPath)
        {
            string properties = "";
            properties += "        public long? SelectedOganizationOid { get; set; }" + Environment.NewLine;
            properties += "        public long? SelectedUserGroupOid { get; set; }" + Environment.NewLine;
            var creator = new CriteriaCreatorManager(companyName, projectName, projectPath, properties, "LookupUserCriteria");
            return FileHelperManager.Instance.WriteFile(projectPath, creator.Path, creator.ClassName + ".cs", creator.ClassString);
        }
    }
}

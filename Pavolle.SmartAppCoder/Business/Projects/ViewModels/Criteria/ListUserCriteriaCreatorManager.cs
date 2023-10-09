using Pavolle.SmartAppCoder.Common.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pavolle.SmartAppCoder.Business.Projects.ViewModels.Criteria
{
    internal class ListUserCriteriaCreatorManager : Singleton<ListUserCriteriaCreatorManager>
    {
        private ListUserCriteriaCreatorManager() { }
        public bool Write(string companyName, string projectName, string projectPath)
        {
            string properties = "";
            properties += "        public long? SelectedOrganizationOid { get; set; }" + Environment.NewLine;
            properties += "        public long? SelectedUserGroupOid { get; set; }" + Environment.NewLine;
            properties += "        public string UsernameContains { get; set; }" + Environment.NewLine;
            properties += "        public string PhoneNumberContains { get; set; }" + Environment.NewLine;
            properties += "        public string EmailContains { get; set; }" + Environment.NewLine;
            var creator = new CriteriaCreatorManager(companyName, projectName, projectPath, properties, "ListUserCriteria");
            return FileHelperManager.Instance.WriteFile(projectPath, creator.Path, creator.ClassName + ".cs", creator.ClassString);
        }
    }
}

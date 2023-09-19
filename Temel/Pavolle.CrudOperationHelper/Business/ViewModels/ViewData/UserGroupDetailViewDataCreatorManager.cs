using Pavolle.Core.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pavolle.CrudOperationHelper.Business.ViewModels.ViewData
{
    public class UserGroupDetailViewDataCreatorManager : Singleton<UserGroupDetailViewDataCreatorManager>, ICreatorManager
    {
        private UserGroupDetailViewDataCreatorManager()
        {

        }
        public bool Write(string companyName, string projectName, string projectPath)
        {
            string properties = "";
            properties += "        public long OrganizationOid { get; set; }" + Environment.NewLine;
            properties += "        public string Name { get; set; }" + Environment.NewLine;
            properties += "        public EUserType UserType { get; set; }" + Environment.NewLine;
            var creator = new ViewDataCreatorManager(companyName, projectName, projectPath, properties, "UserGroupDetailViewData", projectName + "ViewDataBase");
            return FileHelperManager.Instance.WriteFile(projectPath, creator.Path, creator.ClassName + ".cs", creator.ClassString);
        }
    }
}

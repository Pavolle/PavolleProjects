using Pavolle.Core.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pavolle.CrudOperationHelper.Business.ViewModels.ViewData
{
    public class UserViewDataCreatorManager : Singleton<UserViewDataCreatorManager>, ICreatorManager
    {
        private UserViewDataCreatorManager()
        {

        }
        public bool Write(string companyName, string projectName, string projectPath)
        {
            string properties = "";
            properties += "        public long? OrganizationOid { get; set; }" + Environment.NewLine;
            properties += "        public string OrganizationName { get; set; }" + Environment.NewLine;
            properties += "        public long UserGroupOid { get; set; }" + Environment.NewLine;
            properties += "        public string UserGroupName { get; set; }" + Environment.NewLine;
            properties += "        public string Username { get; set; }" + Environment.NewLine;
            properties += "        public EUserType UserType { get; set; }" + Environment.NewLine;
            properties += "        public string Name { get; set; }" + Environment.NewLine;
            properties += "        public string Surname { get; set; }" + Environment.NewLine;
            properties += "        public string Email { get; set; }" + Environment.NewLine;
            properties += "        public string PhoneNumber { get; set; }" + Environment.NewLine;
            var creator = new ViewDataCreatorManager(companyName, projectName, projectPath, properties, "UserViewData", projectName + "ViewDataBase");
            return FileHelperManager.Instance.WriteFile(projectPath, creator.Path, creator.ClassName + ".cs", creator.ClassString);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pavolle.SmartAppCoder.Business;
using Pavolle.SmartAppCoder.Common.Utils;

namespace Pavolle.SmartAppCoder.Business.Projects.Common.Enums
{
    public class UserTypeCreatorManager : Singleton<UserTypeCreatorManager>
    {
        CommonEnumCreatorManager _creator;
        private UserTypeCreatorManager() { }

        public bool Create(string companyName, string projectName, string projectPath)
        {
            _creator = new CommonEnumCreatorManager(companyName, projectName, projectPath, "EUserType");
            string icerik = "";
            icerik += "        SystemAdmin = 1," + Environment.NewLine;
            icerik += "        SystemUser = 2," + Environment.NewLine;
            icerik += "        OrganizationAdmin = 3," + Environment.NewLine;
            icerik += "        OrganizationUser = 4" + Environment.NewLine;
            return FileHelperManager.Instance.WriteFile(projectPath, _creator.Path, _creator.ClassName + ".cs", _creator.EnumClass.Replace("//<EnumContent>", icerik));
        }
    }
}

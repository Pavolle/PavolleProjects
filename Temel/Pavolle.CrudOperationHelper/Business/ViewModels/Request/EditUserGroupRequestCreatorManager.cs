using Pavolle.Core.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pavolle.CrudOperationHelper.Business.ViewModels.Request
{
    internal class EditUserGroupRequestCreatorManager : Singleton<EditUserGroupRequestCreatorManager>
    {
        private EditUserGroupRequestCreatorManager() { }
        public bool Write(string companyName, string projectName, string projectPath)
        {
            string properties = "";
            properties += "        public string Name { get; set; }" + Environment.NewLine;
            properties += "        public EUserType? UserType { get; set; }" + Environment.NewLine;
            properties += "        public List<UserGroupAuthRequestModel> Auhtorizations { get; set; }" + Environment.NewLine;
            var creator = new RequestCreatorManager(companyName, projectName, projectPath, properties, "EditUserGroupRequest", projectName + "RequestBase");
            return FileHelperManager.Instance.WriteFile(projectPath, creator.Path, creator.ClassName + ".cs", creator.ClassString);
        }
    }
}

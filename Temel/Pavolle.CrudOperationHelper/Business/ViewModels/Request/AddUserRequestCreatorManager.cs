using Pavolle.Core.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pavolle.CrudOperationHelper.Business.ViewModels.Request
{
    public class AddUserRequestCreatorManager : Singleton<AddUserRequestCreatorManager>, ICreatorManager
    {
        private AddUserRequestCreatorManager() { }
        public bool Write(string companyName, string projectName, string projectPath)
        {
            string properties = "";
            properties += "        public long? UserGroupOid { get; set; }" + Environment.NewLine;
            properties += "        public string Username { get; set; }" + Environment.NewLine;
            properties += "        public string Name { get; set; }" + Environment.NewLine;
            properties += "        public string Surname { get; set; }" + Environment.NewLine;
            properties += "        public string Email { get; set; }" + Environment.NewLine;
            properties += "        public string PhoneNumber { get; set; }" + Environment.NewLine;
            properties += "        public string Password { get; set; }" + Environment.NewLine;
            var creator = new RequestCreatorManager(companyName, projectName, projectPath, properties, "AddUserRequest", projectName + "RequestBase");
            return FileHelperManager.Instance.WriteFile(projectPath, creator.Path, creator.ClassName + ".cs", creator.ClassString);
        }
    }
}
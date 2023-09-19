using Pavolle.Core.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pavolle.CrudOperationHelper.Business.ViewModels.Model
{
    public class UserGroupCacheModelCreatorManager : Singleton<UserGroupCacheModelCreatorManager>, ICreatorManager
    {
        private UserGroupCacheModelCreatorManager() { }
        public bool Write(string companyName, string projectName, string projectPath)
        {
            string properties = "";
            properties += "        public long Oid { get; set; }" + Environment.NewLine;
            properties += "        public string Name { get; set; }" + Environment.NewLine;
            properties += "        public EUserType UserType { get; set; }" + Environment.NewLine;
            properties += "        public long? OrganizationOid { get; set; }" + Environment.NewLine;
            properties += "        public string OrganizationName { get; set; }" + Environment.NewLine;
            var creator = new ModelCreatorManager(companyName, projectName, projectPath, properties, "UserGroupCacheModel");
            return FileHelperManager.Instance.WriteFile(projectPath, creator.Path, creator.ClassName + ".cs", creator.ClassString);
        }
    }
}

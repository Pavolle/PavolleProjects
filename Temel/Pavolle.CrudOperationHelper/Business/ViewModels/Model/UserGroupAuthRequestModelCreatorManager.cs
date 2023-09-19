using Pavolle.Core.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pavolle.CrudOperationHelper.Business.ViewModels.Model
{
    public class UserGroupAuthRequestModelCreatorManager : Singleton<UserGroupAuthRequestModelCreatorManager>, ICreatorManager
    {
        private UserGroupAuthRequestModelCreatorManager() { }
        public bool Write(string companyName, string projectName, string projectPath)
        {
            string properties = "";
            properties += "        public long ApiServiceOid { get; set; }" + Environment.NewLine;
            properties += "        public bool IsAuthority { get; set; }" + Environment.NewLine;
            var creator = new ModelCreatorManager(companyName, projectName, projectPath, properties, "UserGroupAuthRequestModel");
            return FileHelperManager.Instance.WriteFile(projectPath, creator.Path, creator.ClassName + ".cs", creator.ClassString);
        }
    }
}

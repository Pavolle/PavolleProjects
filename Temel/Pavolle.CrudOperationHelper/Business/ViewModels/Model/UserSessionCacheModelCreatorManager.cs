using Pavolle.Core.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pavolle.CrudOperationHelper.Business.ViewModels.Model
{
    public class UserSessionCacheModelCreatorManager : Singleton<UserSessionCacheModelCreatorManager>, ICreatorManager
    {
        private UserSessionCacheModelCreatorManager() { }
        public bool Write(string companyName, string projectName, string projectPath)
        {
            string properties = "";
            properties += "        public string SessionId { get; set; }" + Environment.NewLine;
            properties += "        public string RequestIp { get; set; }" + Environment.NewLine;
            properties += "        public string Token { get; set; }" + Environment.NewLine;
            properties += "        public DateTime LastOperationTime { get; set; }" + Environment.NewLine;
            properties += "        public string Username { get; set; }" + Environment.NewLine;
            var creator = new ModelCreatorManager(companyName, projectName, projectPath, properties, "UserSessionCacheModel");
            return FileHelperManager.Instance.WriteFile(projectPath, creator.Path, creator.ClassName + ".cs", creator.ClassString);
        }
    }
}

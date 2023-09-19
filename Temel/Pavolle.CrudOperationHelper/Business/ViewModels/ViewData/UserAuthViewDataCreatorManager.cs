using Pavolle.Core.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pavolle.CrudOperationHelper.Business.ViewModels.ViewData
{
    public class UserAuthViewDataCreatorManager : Singleton<UserAuthViewDataCreatorManager>, ICreatorManager
    {
        private UserAuthViewDataCreatorManager()
        {

        }
        public bool Write(string companyName, string projectName, string projectPath)
        {
            string properties = "";
            properties += "        public string ApiKey { get; set; }" + Environment.NewLine;
            properties += "        public bool IsAuthority { get; set; }" + Environment.NewLine;
            var creator = new ViewDataCreatorManager(companyName, projectName, projectPath, properties, "UserAuthViewData", projectName + "ViewDataBase");
            return FileHelperManager.Instance.WriteFile(projectPath, creator.Path, creator.ClassName + ".cs", creator.ClassString);
        }
    }
}

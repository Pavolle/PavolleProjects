using Pavolle.Core.Utils;
using Pavolle.CrudOperationHelper.Business.ViewModels.Criteria;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pavolle.CrudOperationHelper.Business.WebApp.Controller
{
    public class ApiServiceConrollerCreatorManager:Singleton<ApiServiceConrollerCreatorManager>, ICreatorManager
    {
        private ApiServiceConrollerCreatorManager() { }

        public bool Write(string companyName, string projectName, string projectPath)
        {
            string properties = "";
            var creator = new ControllerCreatorManager(companyName, projectName, projectPath, "ApiService");
            string icerik = creator.GenerateGenericService(true, false, true, false, true, false, "");
            return FileHelperManager.Instance.WriteFile(projectPath, creator.Path, creator.ClassName + "Controller.cs",icerik);
        }
    }
}

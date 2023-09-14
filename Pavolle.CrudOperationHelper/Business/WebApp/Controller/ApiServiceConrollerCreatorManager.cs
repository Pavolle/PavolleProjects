using Pavolle.Core.Utils;
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
            return false;
        }
    }
}

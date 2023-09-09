using Pavolle.Core.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pavolle.CrudOperationHelper.Business.ViewModels.Request
{
    public class RequestBaseCreatorManager : Singleton<RequestBaseCreatorManager>, ICreatorManager
    {
        private RequestBaseCreatorManager()
        {

        }

        public bool Write(string companyName, string projectName, string projectPath)
        {
            throw new NotImplementedException();
        }
    }
}

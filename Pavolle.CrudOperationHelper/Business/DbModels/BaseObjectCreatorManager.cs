using Pavolle.Core.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pavolle.CrudOperationHelper.Business.DbModels
{
    public class BaseObjectCreatorManager : Singleton<BaseObjectCreatorManager>, ICreatorManager
    {
        DbModelCreatorManager creator;

        private BaseObjectCreatorManager()
        {

        }

        public bool Write(string companyName, string projectName, string projectPath)
        {
            throw new NotImplementedException();
        }
    }
}

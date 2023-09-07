using Pavolle.Core.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pavolle.CrudOperationHelper.Business.DbModels
{
    public class JobCreatorManager : Singleton<BaseObjectCreatorManager>, ICreatorManager
    {
        DbModelCreatorManager creator;

        private BaseObjectCreatorManager()
        {

        }
    }
}

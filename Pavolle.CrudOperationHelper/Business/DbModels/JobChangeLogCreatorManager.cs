using Pavolle.Core.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pavolle.CrudOperationHelper.Business.DbModels
{
    internal class JobChangeLogCreatorManager : Singleton<JobChangeLogCreatorManager>, ICreatorManager
    {
        DbModelCreatorManager creator;

        private JobChangeLogCreatorManager()
        {

        }

        public bool Write(string companyName, string projectName, string projectPath)
        {
            throw new NotImplementedException();
        }
    }
}

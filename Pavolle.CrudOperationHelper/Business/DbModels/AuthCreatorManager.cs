using Pavolle.Core.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pavolle.CrudOperationHelper.Business.DbModels
{
    public class AuthCreatorManager : Singleton<AuthCreatorManager>, ICreatorManager
    {
        DbModelCreatorManager creator;

        private AuthCreatorManager()
        {

        }

        public bool Write(string companyName, string projectName, string projectPath)
        {
            throw new NotImplementedException();
        }
    }
}

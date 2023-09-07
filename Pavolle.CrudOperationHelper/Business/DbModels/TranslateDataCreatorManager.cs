using Pavolle.Core.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pavolle.CrudOperationHelper.Business.DbModels
{
    public class TranslateDataCreatorManager : Singleton<TranslateDataCreatorManager>, ICreatorManager
    {
        DbModelCreatorManager creator;

        private TranslateDataCreatorManager()
        {

        }

        public bool Write(string companyName, string projectName, string projectPath)
        {
            throw new NotImplementedException();
        }
    }
}

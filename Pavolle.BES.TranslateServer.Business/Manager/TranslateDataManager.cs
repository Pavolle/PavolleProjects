using Pavolle.BES.TranslateServer.ViewModels.Request;
using Pavolle.BES.ViewModels.Request;
using Pavolle.Core.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pavolle.BES.TranslateServer.Business.Manager
{
    public class TranslateDataManager : Singleton<TranslateDataManager>
    {
        private TranslateDataManager() { }

        public object AddTranslateData(AddTranslateDataRequest request)
        {
            throw new NotImplementedException();
        }

        public object Detail(long? oid, IntegrationAppRequestBase request)
        {
            throw new NotImplementedException();
        }

        public object EditTranslateData(long? oid, EditTranslateDataRequest request)
        {
            throw new NotImplementedException();
        }

        public object GetAllData(IntegrationAppRequestBase request)
        {
            throw new NotImplementedException();
        }

        public object GetData(string variable, IntegrationAppRequestBase request)
        {
            throw new NotImplementedException();
        }
    }
}

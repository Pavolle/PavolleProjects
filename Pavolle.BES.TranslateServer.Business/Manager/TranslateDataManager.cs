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

        public object GetAllData(IntegrationAppRequestBase request)
        {
            throw new NotImplementedException();
        }
    }
}

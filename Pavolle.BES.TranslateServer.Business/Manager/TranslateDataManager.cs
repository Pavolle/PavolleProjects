using log4net;
using Pavolle.BES.TranslateServer.Common.Enums;
using Pavolle.BES.TranslateServer.ViewModels.Model;
using Pavolle.BES.TranslateServer.ViewModels.Request;
using Pavolle.BES.TranslateServer.ViewModels.Response;
using Pavolle.BES.ViewModels.Request;
using Pavolle.Core.Enums;
using Pavolle.Core.Utils;
using Pavolle.Core.ViewModels.Response;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pavolle.BES.TranslateServer.Business.Manager
{
    public class TranslateDataManager : Singleton<TranslateDataManager>
    {
        static readonly ILog _log = LogManager.GetLogger(typeof(TranslateDataManager));

        ConcurrentDictionary<string, TranslateDataCacheModel> _translateDataList;
        private TranslateDataManager() 
        {
        }

        public void Initialize()
        {
            _translateDataList = new ConcurrentDictionary<string, TranslateDataCacheModel>();
        }

        public ResponseBase AddTranslateData(AddTranslateDataRequest request)
        {
            throw new NotImplementedException();
        }

        public TranslateDataDetailResponse Detail(long? oid, IntegrationAppRequestBase request)
        {
            throw new NotImplementedException();
        }

        public ResponseBase EditTranslateData(long? oid, EditTranslateDataRequest request)
        {
            throw new NotImplementedException();
        }

        public TranslateDataListResponse GetAllData(IntegrationAppRequestBase request)
        {
            throw new NotImplementedException();
        }

        public TranslateDataResponse GetData(string variable, IntegrationAppRequestBase request)
        {
            throw new NotImplementedException();
        }

        internal void AddCacheDataFromMessageCodeEnum(EMessageCode messageCode)
        {
            AddTranslateCacheData(new TranslateDataCacheModel
            {
                Variable = messageCode.ToString(),
                EN = messageCode.Description()
            });
        }

        internal void AddTranslateCacheData(TranslateDataCacheModel item)
        {
            if(!_translateDataList.ContainsKey(item.Variable))
            {
                _translateDataList.TryAdd(item.Variable, item);
            }
        }

        internal void AddCacheDataFromLanguageEnum(ELanguage language)
        {
            var data = new TranslateDataCacheModel
            {
                Variable = language.ToString(),
                EN = language.ToString()
            };

            AddTranslateCacheData(data);
        }
    }
}

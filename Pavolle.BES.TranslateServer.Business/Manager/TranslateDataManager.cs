using log4net;
using Pavolle.BES.Business;
using Pavolle.BES.Common.Enums;
using Pavolle.BES.TranslateServer.Common.Enums;
using Pavolle.BES.TranslateServer.ViewModels.Model;
using Pavolle.BES.TranslateServer.ViewModels.Request;
using Pavolle.BES.TranslateServer.ViewModels.Response;
using Pavolle.BES.TranslateServer.ViewModels.ViewData;
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
using static System.Runtime.InteropServices.JavaScript.JSType;

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
            var response= new TranslateDataListResponse();
            response.DataList= _translateDataList.Values.Where(t=>t.AppType==null || t.AppType == AppIdManager.Instance.GetBesAppTypeByAppId(request.AppId)).Select(data=> new TranslateDataViewData
            {
                Variable = data.Variable,
                AppType = data.AppType,
                EN = data.EN,
                FR = data.FR,
                ES = data.ES,
                RU = data.RU,
                AZ = data.AZ,
                TR = data.TR,
                DE = data.DE,
            }).ToList();
            return response;
        }

        public TranslateDataResponse GetData(string variable, IntegrationAppRequestBase request)
        {
            var response=new TranslateDataResponse();   
            if(!_translateDataList.ContainsKey(variable))
            {
                response.ErrorMessage = GetMessageFromMessageCode(EMessageCode.RecordNotFoundException, request.Language.Value);
                response.StatusCode = 400;
                return response;
            }
            var data = _translateDataList[variable];
            response.Data = new TranslateDataViewData
            {
                Variable = data.Variable,
                AppType = data.AppType,
                EN = data.EN,
                FR = data.FR,
                ES = data.ES,
                RU = data.RU,
                AZ = data.AZ,
                TR = data.TR,
                DE = data.DE,
            };
            return response;
        }

        private string GetMessageFromMessageCode(EMessageCode messageCode, ELanguage language)
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

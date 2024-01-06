using Pavolle.BES.Common.Enums;
using Pavolle.BES.TranslateServer.Common.Enums;
using Pavolle.BES.TranslateServer.Common.Utils;
using Pavolle.BES.TranslateServer.ViewModels.Model;
using Pavolle.BES.TranslateServer.ViewModels.Request;
using Pavolle.BES.TranslateServer.ViewModels.Response;
using Pavolle.BES.TranslateServer.ViewModels.ViewData;
using Pavolle.BES.ViewModels.Response;
using Pavolle.Core.Enums;
using Pavolle.Core.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pavolle.BES.TranslateServer.ClientLib
{
    public class TranslateServiceManager : Singleton<TranslateServiceManager>
    {
        List<TranslateDataCacheModel> _translateData;
        private TranslateServiceManager() { }
        public void Initialize() 
        {
            var response = TranslateServerHelperManager.Instance.Get<TranslateDataListResponse>(TranslateServerUrlConsts.TranslateDataUrlConst.BaseRoute + "/" + TranslateServerUrlConsts.TranslateDataUrlConst.GetAllDataRoutePrefix);
            if (response != null)
            {
                _translateData = response.DataList.Select(t => new TranslateDataCacheModel
                {
                    Oid = t.Oid,
                    AppType = t.AppType,
                    AZ = t.AZ,
                    DE = t.DE,
                    EN = t.EN,
                    RU = t.RU,
                    FR = t.FR,
                    ES = t.ES,
                    TR = t.TR,
                    Variable = t.Variable
                }).ToList();
            }
        }

        public string GetMessage(EMessageCode messageCode, ELanguage language)
        {
            return GetMessage(messageCode.ToString(), language);
        }

        public string GetMessage(string messageCode, ELanguage language)
        {
            if(_translateData == null)
            {
                return messageCode;
            }
            var data = _translateData.FirstOrDefault(t => t.Variable == messageCode);
            if(data == null)
            {
                return messageCode;
            }
            switch (language)
            {
                case ELanguage.English:
                    return string.IsNullOrWhiteSpace( data.EN) ? string.Empty : data.EN;
                case ELanguage.Russian:
                    return string.IsNullOrWhiteSpace(data.RU) ? string.Empty : data.RU;
                case ELanguage.Turkish:
                    return string.IsNullOrWhiteSpace(data.TR) ? string.Empty : data.TR;
                case ELanguage.Azerbaijani:
                    return string.IsNullOrWhiteSpace(data.AZ) ? string.Empty : data.AZ;
                case ELanguage.Spanish:
                    return string.IsNullOrWhiteSpace(data.ES) ? string.Empty : data.ES;
                case ELanguage.French:
                    return string.IsNullOrWhiteSpace(data.FR) ? string.Empty : data.FR;
                case ELanguage.German:
                    return string.IsNullOrWhiteSpace(data.DE) ? string.Empty : data.DE;
                    default: return messageCode;
            }
        }

        public BesAddRecordResponseBase SaveNewData(string variable, ELanguage? language, EBesAppType besAppType)
        {
            return TranslateServerHelperManager.Instance.Post<BesAddRecordResponseBase>(TranslateServerUrlConsts.TranslateDataUrlConst.BaseRoute + "/" + TranslateServerUrlConsts.TranslateDataUrlConst.AddRoutePrefix, new AddTranslateDataRequest
            {
                CurrentLanguage = language,
                Variable = variable,
                Value=variable
            });
        }

        public TranslateDataCacheModel? GetDataByOid(long nameTranslateDataOid, EBesAppType besAppType)
        {
            return _translateData.FirstOrDefault(t => t.Oid == nameTranslateDataOid);
        }

        public string GetNameFromCacheData(TranslateDataCacheModel data, ELanguage? language)
        {
            if(language==null) { return data.Variable; }
            switch (language.Value)
            {
                case ELanguage.German:
                    return data.DE;
                case ELanguage.Spanish:
                    return data.ES;
                case ELanguage.English:
                    return data.EN;
                case ELanguage.Russian:
                    return data.RU;
                case ELanguage.French:
                    return data.FR;
                case ELanguage.Turkish:
                    return data.TR;
                default:return data.Variable;
            }
        }
    }
}

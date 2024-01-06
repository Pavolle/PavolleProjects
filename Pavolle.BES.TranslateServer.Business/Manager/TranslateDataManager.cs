using DevExpress.Xpo;
using log4net;
using Pavolle.BES.Business;
using Pavolle.BES.Common.Enums;
using Pavolle.BES.TranslateServer.Common.Enums;
using Pavolle.BES.TranslateServer.DbModels;
using Pavolle.BES.TranslateServer.DbModels.Entities;
using Pavolle.BES.TranslateServer.ViewModels.Model;
using Pavolle.BES.TranslateServer.ViewModels.Request;
using Pavolle.BES.TranslateServer.ViewModels.Response;
using Pavolle.BES.TranslateServer.ViewModels.ViewData;
using Pavolle.BES.ViewModels.Request;
using Pavolle.BES.ViewModels.Response;
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

        public BesAddRecordResponseBase AddTranslateData(AddTranslateDataRequest request)
        {
            var response=new BesAddRecordResponseBase();    
            using(Session session = TranslateServerXpoManager.Instance.GetNewSession())
            {
                var data = new TranslateData(session)
                {
                    Variable = request.Variable,
                    AppType = AppIdManager.Instance.GetBesAppTypeByAppId(request.AppId),
                };
                switch (request.CurrentLanguage.Value)
                {
                    case ELanguage.English:
                        data.EN = request.Value;
                        break;
                    case ELanguage.German:
                        data.DE = request.Value;
                        break;
                    case ELanguage.Spanish:
                        data.ES = request.Value;
                        break;
                    case ELanguage.French:
                        data.FR = request.Value;
                        break;
                    case ELanguage.Russian:
                        data.RU = request.Value;
                        break;
                    case ELanguage.Turkish:
                        data.TR = request.Value;
                        break;
                    case ELanguage.Azerbaijani:
                        data.AZ = request.Value;
                        break;
                    default:
                        data.EN = request.Value;
                        break;
                }
                data.Save();

                response.RecordOid = data.Oid;

                AddTranslateCacheData(new TranslateDataCacheModel
                {
                    Variable = data.Variable,
                    DE = data.DE,
                    FR = data.FR,
                    RU = data.RU,
                    AZ = data.AZ,
                    EN = data.EN,
                    TR = data.TR,
                    ES = data.ES,
                    AppType = data.AppType
                });
            }
            return response;
        }

        public TranslateDataDetailResponse Detail(long? oid, IntegrationAppRequestBase request)
        {
            var response = new TranslateDataDetailResponse();
            using (Session session = TranslateServerXpoManager.Instance.GetNewSession())
            {
                var data = session.Query<TranslateData>().FirstOrDefault(t => t.Oid == oid);
                if (data == null)
                {
                    response.ErrorMessage = GetMessageFromMessageCode(EMessageCode.RecordNotFoundException, request.Language.Value);
                    response.StatusCode = 400;
                    return response;
                }
                response.Detail = new TranslateDataViewData
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
            }
            return response;
        }

        public ResponseBase EditTranslateData(long? oid, EditTranslateDataRequest request)
        {
            var response = new ResponseBase();
            using (Session session = TranslateServerXpoManager.Instance.GetNewSession())
            {
                var data = session.Query<TranslateData>().FirstOrDefault(t => t.Oid == oid);
                if (data == null)
                {
                    response.ErrorMessage = GetMessageFromMessageCode(EMessageCode.RecordNotFoundException, request.Language.Value);
                    response.StatusCode = 400;
                    return response;
                }

                data.EN = request.EN;
                data.FR = request.FR;
                data.ES = request.ES;
                data.RU = request.RU;
                data.AZ = request.AZ;
                data.TR = request.TR;
                data.DE = request.DE;

                data.LastUpdateTime=DateTime.Now;

                UpdateCacheData(new TranslateDataCacheModel
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
                });
            }
            return response;
        }

        private void UpdateCacheData(TranslateDataCacheModel item)
        {
            if (!_translateDataList.ContainsKey(item.Variable))
            {
                _translateDataList.TryAdd(item.Variable, item);
            }
            else
            {
                _translateDataList[item.Variable] = item;
            }
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

        //TODO Bu kısmın yazılması lazım. Çünkü diğer servislerin tamamı Service üzerinden veri aldığı için kodlar orada yazıldı. Burada direk veri üzerinden sorgulanması gerekiyor.
        private string GetMessageFromMessageCode(EMessageCode messageCode, ELanguage language)
        {
            //return GetData(messageCode.ToString(), new IntegrationAppRequestBase { Language = language }).Data;
            return "";
        }

        internal void AddTranslateCacheData(TranslateDataCacheModel item)
        {
            if(!_translateDataList.ContainsKey(item.Variable))
            {
                _translateDataList.TryAdd(item.Variable, item);
            }
        }

    }
}

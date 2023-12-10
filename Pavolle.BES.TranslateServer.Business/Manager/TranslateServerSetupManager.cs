using DevExpress.Xpo;
using Pavolle.BES.TranslateServer.Common.Enums;
using Pavolle.BES.TranslateServer.DbModels;
using Pavolle.BES.TranslateServer.DbModels.Entities;
using Pavolle.BES.TranslateServer.ViewModels.Model;
using Pavolle.BES.TranslateServer.ViewModels.Request;
using Pavolle.Core.Enums;
using Pavolle.Core.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pavolle.BES.TranslateServer.Business.Manager
{
    public class TranslateServerSetupManager : Singleton<TranslateServerSetupManager>
    {
        private TranslateServerSetupManager()
        {

        }

        public void Initialize()
        {
            var messageCodeList = Enum.GetValues(typeof(EMessageCode)).Cast<EMessageCode>().ToList();
            var languageList = Enum.GetValues(typeof(ELanguage)).Cast<ELanguage>().ToList();

            using (Session session = TranslateServerXpoManager.Instance.GetNewSession())
            {
                var dataList = session.Query<TranslateData>().Select(t => new TranslateDataCacheModel
                {
                    Variable=t.Variable,
                    AppType=t.AppType,
                    TR=t.TR,
                    AZ=t.AZ,
                    DE=t.DE,
                    EN=t.EN,
                    ES=t.ES,
                    FR=t.FR,
                    RU = t.RU
                }).ToList();

                foreach (var item in dataList)
                {
                    TranslateDataManager.Instance.AddTranslateCacheData(item);
                }

                foreach (var messageCode in messageCodeList)
                {
                    if (!dataList.Any(t => t.Variable == messageCode.ToString()))
                    {
                        TranslateDataManager.Instance.AddTranslateCacheData(GetCacheDataFromTranslateData(GetMessageCodeTranslateData(session, messageCode)));
                    }
                }

                foreach (var language in languageList)
                {
                    if (!dataList.Any(t => t.Variable == language.ToString()))
                    {
                        TranslateDataManager.Instance.AddTranslateCacheData(GetCacheDataFromTranslateData(GetLanguageTranslateData(session, language)));
                    }
                }
            }

        }

        private TranslateDataCacheModel GetCacheDataFromTranslateData(TranslateData translateData)
        {
            return new TranslateDataCacheModel
            {
                Variable = translateData.Variable,
                AppType = translateData.AppType,
                EN = translateData.EN,
                TR = translateData.TR,
                RU = translateData.RU,
                AZ = translateData.AZ,
                DE = translateData.DE,
                FR = translateData.FR,
                ES = translateData.ES
            };
        }

        private TranslateData GetLanguageTranslateData(Session session, ELanguage language)
        {
            var data = new TranslateData(session)
            {
                Variable = language.ToString(),
                EN = language.ToString()
            };

            switch (language)
            {
                case ELanguage.Turkish:
                    data.RU = "";
                    data.AZ = "Türkce";
                    data.DE = "";
                    data.ES = "";
                    data.FR = "";
                    data.TR = "Türkçe";
                    break;
                case ELanguage.French:
                    data.RU = "";
                    data.AZ = "Fransızca";
                    data.DE = "";
                    data.ES = "";
                    data.FR = "";
                    data.TR = "Fransızca";
                    break;
                case ELanguage.German:
                    data.RU = "";
                    data.AZ = "Almanca";
                    data.DE = "";
                    data.ES = "";
                    data.FR = "";
                    data.TR = "Almanca";
                    break;
                case ELanguage.Spanish:
                    data.RU = "";
                    data.AZ = "İspanca";
                    data.DE = "";
                    data.ES = "";
                    data.FR = "";
                    data.TR = "İspanyolca";
                    break;
                case ELanguage.Azerbaijani:
                    data.RU = "";
                    data.AZ = "Azərbaycanca";
                    data.DE = "";
                    data.ES = "";
                    data.FR = "";
                    data.TR = "Azerice";
                    break;
                case ELanguage.Russian:
                    data.RU = "";
                    data.AZ = "Rusca";
                    data.DE = "";
                    data.ES = "";
                    data.FR = "";
                    data.TR = "Rusça";
                    break;
            }

            data.Save();
            return data;
        }

        private TranslateData GetMessageCodeTranslateData(Session session, EMessageCode messageCode)
        {
            var data = new TranslateData(session)
            {
                Variable = messageCode.ToString(),
                EN = messageCode.Description()
            };

            switch (messageCode)
            {
                case EMessageCode.UnexpectedExceptionOccured:
                    data.RU = "";
                    data.AZ = "";
                    data.DE = "";
                    data.ES = "";
                    data.FR = "";
                    data.TR = "Beklenmedik hata oluştu!";
                    break;
                case EMessageCode.RequestDataTypeError:
                    data.RU = "";
                    data.AZ = "";
                    data.DE = "";
                    data.ES = "";
                    data.FR = "";
                    data.TR = "Parametre türü hatalı!";
                    break;
                case EMessageCode.UnauthorizedException:
                    data.RU = "";
                    data.AZ = "";
                    data.DE = "";
                    data.ES = "";
                    data.FR = "";
                    data.TR = "Giriş yetkiniz bulunmamaktadır!";
                    break;
                case EMessageCode.Header:
                    data.RU = "";
                    data.AZ = "";
                    data.DE = "";
                    data.ES = "";
                    data.FR = "";
                    data.TR = "Başlık";
                    break;
                case EMessageCode.RecordNotFoundException:
                    data.RU = "";
                    data.AZ = "";
                    data.DE = "";
                    data.ES = "";
                    data.FR = "";
                    data.TR = "Veri bulunamadı!";
                    break;
                case EMessageCode.DataSavedSuccessfully:
                    data.RU = "";
                    data.AZ = "";
                    data.DE = "";
                    data.ES = "";
                    data.FR = "";
                    data.TR = "Veri kaydedildi.";
                    break;
                case EMessageCode.DataCreatedBefore:
                    data.RU = "";
                    data.AZ = "";
                    data.DE = "";
                    data.ES = "";
                    data.FR = "";
                    data.TR = "Veri daha önce kaydedilmiş!";
                    break;
                case EMessageCode.UsernameOrPasswordNotCorrect:
                    data.RU = "";
                    data.AZ = "";
                    data.DE = "";
                    data.ES = "";
                    data.FR = "";
                    data.TR = "Kullanıcı adı veya parola hatalı!";
                    break;
                default:
                    break;
            }

            data.Save();
            return data;
        }
    }
}

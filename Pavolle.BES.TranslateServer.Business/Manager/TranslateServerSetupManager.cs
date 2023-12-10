using DevExpress.Xpo;
using Pavolle.BES.TranslateServer.Common.Enums;
using Pavolle.BES.TranslateServer.DbModels;
using Pavolle.BES.TranslateServer.DbModels.Entities;
using Pavolle.BES.TranslateServer.ViewModels.Model;
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

            using(Session session = TranslateServerXpoManager.Instance.GetNewSession())
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
                        new TranslateData(session)
                        {
                            Variable = messageCode.ToString(),
                            EN=messageCode.Description()
                        }.Save();

                        TranslateDataManager.Instance.AddCacheDataFromMessageCodeEnum(messageCode);
                    }
                }
            }

        }
    }
}

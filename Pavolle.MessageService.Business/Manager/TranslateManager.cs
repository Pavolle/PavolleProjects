using DevExpress.Xpo;
using Pavolle.Core.Enums;
using Pavolle.Core.Utils;
using Pavolle.MessageService.Common.Enums;
using Pavolle.MessageService.DbModels;
using Pavolle.MessageService.DbModels.Entities;
using Pavolle.MessageService.ViewModels.ViewData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pavolle.MessageService.Business.Manager
{
    public class TranslateManager:Singleton<TranslateManager>
    {
        List<TranslateViewData> _translateDatas;
        private TranslateManager() { }

        public void Initialize()
        {
            using (Session session = XpoManager.Instance.GetNewSession())
            {
                _translateDatas = session.Query<TranslateData>().Select(t => new TranslateViewData
                {
                    Oid = t.Oid,
                    CreatedTime = t.CreatedTime,
                    LastUpdateTime = t.LastUpdateTime,
                    Variable = t.Variable,
                    EN = t.EN,
                    TR = t.TR
                }).ToList();
            }
        }

        public void Setup()
        {
            //Enumları tabloya yazacak

            using (Session session = XpoManager.Instance.GetNewSession())
            {

                InitalizeEnumValue<EUserType>(session);
            }
        }

        void InitalizeEnumValue<T>(Session session)
        {
            List<string> values = Enum.GetValues(typeof(T)).Cast<T>().ToList().Select(t => t.ToString()).ToList();
            foreach (var item in values)
            {
                if (!session.Query<TranslateData>().Any(t => t.Variable == item))
                {
                    new TranslateData(session)
                    {
                        Variable = item,
                        TR = "",
                        EN = ""
                    }.Save();
                }
            }
        }
    }
}

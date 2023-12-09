using DevExpress.Xpo;
using Pavolle.BES.AuthServer.Common.Enums;
using Pavolle.BES.AuthServer.DbModels;
using Pavolle.BES.AuthServer.DbModels.Entities;
using Pavolle.BES.AuthServer.ViewModels.Model;
using Pavolle.Core.Utils;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pavolle.BES.AuthServer.Business.Manager
{
    public class CommunicationInfoManager : Singleton<CommunicationInfoManager>
    {
        ConcurrentDictionary<long, List<CommunicationInfoCacheModel>> _communicationInfo;
        private CommunicationInfoManager() { }


        public bool LoadCacheData()
        {
            bool success = false;

            using(Session session = AuthServerXpoManager.Instance.GetNewSession())
            {
                var dataList = session.Query<CommunicationInfo>().Select(t => new CommunicationInfoCacheModel
                {
                    PersonOid = t.Oid,
                    CommunicationType = t.CommunicationType,
                    IsDefault = t.IsDefault,
                    IsVerified = t.IsVerified,
                    Value = t.Value
                });

                foreach (var item in dataList)
                {
                    if(_communicationInfo.ContainsKey(item.PersonOid))
                    {
                        _communicationInfo[item.PersonOid].Add(item);
                    }
                    else
                    {
                        _communicationInfo.TryAdd(item.PersonOid, new List<CommunicationInfoCacheModel> { item });
                    }
                }
            }

            return success;
        }

        public string GetPersonDefaultEmailAddress(long personOid)
        {
            string result = "";
            if(!_communicationInfo.ContainsKey(personOid)) return result;
            var data= _communicationInfo[personOid];
            if(data==null) return result;
            var emailData = data.FirstOrDefault(t => t.CommunicationType == ECommunicationType.WorkEmailAddress && t.IsDefault);
            if(emailData==null) return result;
            result = emailData.Value;
            return result;
        }

        public string GetPersonDefaultPhoneNumber(long personOid)
        {
            string result = "";
            if (!_communicationInfo.ContainsKey(personOid)) return result;
            var data = _communicationInfo[personOid];
            if (data == null) return result;
            var phoneData = data.FirstOrDefault(t => t.CommunicationType == ECommunicationType.MobilePhoneNumber && t.IsDefault);
            if (phoneData == null) return result;
            result = phoneData.Value;
            return result;
        }
    }
}

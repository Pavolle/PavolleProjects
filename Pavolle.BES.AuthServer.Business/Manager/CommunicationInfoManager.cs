using Pavolle.Core.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pavolle.BES.AuthServer.Business.Manager
{
    public class CommunicationInfoManager : Singleton<CommunicationInfoManager>
    {
        private CommunicationInfoManager() { }


        public bool LoadCacheData()
        {
            bool success = true;

            return success;
        }

        internal string GetPersonDefaultEmailAddress(long personOid)
        {
            throw new NotImplementedException();
        }

        internal string GetPersonDefaultPhoneNumber(long personOid)
        {
            throw new NotImplementedException();
        }
    }
}

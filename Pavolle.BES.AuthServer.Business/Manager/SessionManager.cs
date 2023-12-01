using Pavolle.BES.AuthServer.Common.Enums;
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
    public class SessionManager : Singleton<SessionManager>
    {
        ConcurrentDictionary<string, TokenCacheModel> _sessions;
        private SessionManager() { }

        public EAddSessionResult AddSession(string sessionId, TokenCacheModel session)
        {
            EAddSessionResult result = EAddSessionResult.Success;

            return result;
        }

        public ERemoveSessionResult RemoveSession(string sessionId)
        {
            ERemoveSessionResult result = ERemoveSessionResult.Success;

            return result;
        }
    }
}

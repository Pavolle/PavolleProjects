using DevExpress.Xpo;
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
        private SessionManager()
        {
            _sessions=new ConcurrentDictionary<string, TokenCacheModel>();
        }

        public EAddSessionResult AddSession(string sessionId, TokenCacheModel session)
        {
            EAddSessionResult result = EAddSessionResult.Success;
            if(IsSessionExist(sessionId))
            {
                result = EAddSessionResult.SessionAddedBefore;
            }
            else 
            { 
                bool addResult=_sessions.TryAdd(sessionId, session);
                if(!addResult) { result = EAddSessionResult.Fail; }
            }
            return result;
        }

        public ERemoveSessionResult RemoveSession(string sessionId)
        {
            ERemoveSessionResult result = ERemoveSessionResult.Success;

            if (!IsSessionExist(sessionId))
            {
                result = ERemoveSessionResult.SessionNotExist;
            }
            else
            {
                TokenCacheModel deletedSession;
                bool removeResult = _sessions.TryRemove(sessionId, out deletedSession);
                if (!removeResult) { result = ERemoveSessionResult.Fail; }
            }
            return result;
        }

        private bool IsSessionExist(string sessionId)
        {
            return _sessions.ContainsKey(sessionId);
        }


        private bool IsSessionValid(string sessionId)
        {
            bool valid= _sessions.ContainsKey(sessionId);
            if(!valid) return false;
            if (_sessions[sessionId].ExpireDateTime < DateTime.Now)
            {
                valid = false;
            }
            return valid;
        }

        public void CleanExpireSession()
        {
            foreach (var session in _sessions)
            {
                if(session.Value.ExpireDateTime < DateTime.Now)
                {
                    RemoveSession(session.Key);
                }
            }
        }
    }
}

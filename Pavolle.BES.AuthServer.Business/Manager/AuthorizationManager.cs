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
    public class AuthorizationManager : Singleton<AuthorizationManager>
    {
        ConcurrentDictionary<long, AuthorizationCacheModel> _authotizations;
        private AuthorizationManager() { }

        public bool LoadCacheData()
        {
            var result = false;

            return result;
        }
    }
}

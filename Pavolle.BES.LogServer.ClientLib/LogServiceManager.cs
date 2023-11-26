using Pavolle.BES.LogServer.Common.Enums;
using Pavolle.Core.Utils;

namespace Pavolle.BES.LogServer.ClientLib
{
    public class LogServiceManager : Singleton<LogServiceManager>
    {
        string _serviceUrl;
        private LogServiceManager() 
        {
        }

        public void Initialize(string serviceUrl)
        {
            _serviceUrl = serviceUrl;
        }
    }
}
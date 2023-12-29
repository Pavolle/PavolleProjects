using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pavolle.BES.MailServer.Common.Utils
{
    public class MailServerUrlConsts
    {
        public class ServerStatusUrlConst
        {
            public const string BaseRoute = "api/mailserver/serverstatus";

            public const string ServerDetailRoutePrefix = "detail";
            public const string ServerSettingsRoutePrefix = "settings";
            public const string ReloadAllServerSettingsRoutePrefix = "reloadallsettings";
        }

        public class MailServiceConsts
        {
            public const string BaseRoute = "api/mailserver/job";

            public const string SendMailRoutePrefix = "sendmail";
            //todo gelecekte gönderilen maillerin listesinin sorgulanacağız servis yazılması gerekiyor.
        }
    }
}

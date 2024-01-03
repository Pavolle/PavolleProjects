using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pavolle.BES.SettingServer.Common.Enums
{
    public enum ESettingCategory
    {
        [Description("General")]
        General = 1,

        [Description("Log Server")]
        LogServer = 2,

        [Description("DYS")]
        DYS = 3,

        [Description("Translate Server")]
        TranslateServer = 4,

        [Description("Mail Server")]
        MailServer = 5,

        [Description("SMS Server")]
        SMSServer = 6,

        [Description("Surrvey")]
        Surrvey = 7,

        [Description("Supplera")]
        Supplera = 8,

        [Description("Geolocation Server")]
        GeolocationServer = 9,
    }
}

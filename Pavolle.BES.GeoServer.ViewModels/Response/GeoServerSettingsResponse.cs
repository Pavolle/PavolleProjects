using Pavolle.Core.Enums;
using Pavolle.Core.ViewModels.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pavolle.BES.GeoServer.ViewModels.Response
{
    public class GeoServerSettingsResponse : ResponseBase
    {
        public ELanguage Language { get; set; }
        public ELanguage SystemLanguage { get; set; }
        public string SettingServerBaseUrl { get; set; }
        public string TranslateServerBaseUrl { get; set; }
        public string DbConnectionString { get; set; }
        public string CountryFlagBaseUrl { get; set; }
    }
}

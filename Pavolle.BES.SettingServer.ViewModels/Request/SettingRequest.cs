using Pavolle.BES.ViewModels.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pavolle.BES.SettingServer.ViewModels.Request
{
    public class SettingRequest : IntegrationAppRequestBase
    {
        public string Value { get; set; }
    }
}

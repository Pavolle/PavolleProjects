using Pavolle.BES.ViewModels.Request;
using Pavolle.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pavolle.BES.TranslateServer.ViewModels.Request
{
    public class AddTranslateDataRequest : IntegrationAppRequestBase
    {
        public string Variable { get; set; }
        public ELanguage? CurrentLanguage { get; set; }
        public string Value { get; set; }
    }
}

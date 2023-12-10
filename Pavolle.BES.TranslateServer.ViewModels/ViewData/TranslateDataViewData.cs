using Pavolle.BES.AppServer.Common.Enums;
using Pavolle.BES.Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pavolle.BES.TranslateServer.ViewModels.ViewData
{
    public class TranslateDataViewData
    {
        public string Variable { get; set; }
        public EBesAppType? AppType { get; set; }
        public string TR { get; set; }
        public string EN { get; set; }
        public string ES { get; set; }
        public string FR { get; set; }
        public string RU { get; set; }
        public string DE { get; set; }
        public string AZ { get; set; }
    }
}

using Pavolle.BES.ViewModels.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pavolle.BES.TranslateServer.ViewModels.Request
{
    public class EditTranslateDataRequest : IntegrationAppRequestBase
    {
        public string TR { get; set; }
        public string EN { get; set; }
        public string ES { get; set; }
        public string FR { get; set; }
        public string RU { get; set; }
        public string DE { get; set; }
        public string AZ { get; set; }
    }
}

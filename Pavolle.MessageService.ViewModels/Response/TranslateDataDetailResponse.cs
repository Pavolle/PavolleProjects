using Pavolle.MessageService.ViewModels.ViewData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pavolle.MessageService.ViewModels.Response
{
    public class TranslateDataDetailResponse : MessageServiceResponseBase
    {
        public TranslateDataDetailViewData Detail { get; set; }
        public List<TranslateDataChangeLogViewData> ChangeLogViewData { get; set; }
    }
}

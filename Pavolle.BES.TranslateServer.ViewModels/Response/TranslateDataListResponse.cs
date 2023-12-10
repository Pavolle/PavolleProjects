using Pavolle.BES.TranslateServer.ViewModels.ViewData;
using Pavolle.Core.ViewModels.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pavolle.BES.TranslateServer.ViewModels.Response
{
    public class TranslateDataListResponse : ResponseBase
    {
        public List<TranslateDataViewData> DataList { get; set; }
    }
}

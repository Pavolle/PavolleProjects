using Pavolle.MessageService.ViewModels.ViewData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pavolle.MessageService.ViewModels.Response
{
    public class CityDetailResponse : MessageServiceResponseBase
    {
        public CityDetailViewData Detail { get; set; }
    }
}

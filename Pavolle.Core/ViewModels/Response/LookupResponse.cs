using Pavolle.Core.ViewModels.ViewData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pavolle.Core.ViewModels.Response
{
    public class LookupResponse:ResponseBase
    {
        public List<LookupViewData> DataList { get; set; }
    }
}

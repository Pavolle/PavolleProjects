using Pavolle.Core.ViewModels.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pavolle.BES.ViewModels.Response
{
    public class BesAddRecordResponseBase : ResponseBase
    {
        public long? RecordOid { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pavolle.Core.ViewModels.Response
{
    public class DetailResponseBase:ResponseBase
    {
        public long Oid { get; set; }
        public DateTime CreatedTime { get; set; }
        public DateTime? LastUpdateTime { get; set; }
    }
}

using Pavolle.Core.ViewModels.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pavolle.BES.DYS.ViewModels.Response
{
    public class DYSIntegrationResponseBase : ResponseBase
    {
        public long? SavedDocumentOid { get; set; }
    }
}

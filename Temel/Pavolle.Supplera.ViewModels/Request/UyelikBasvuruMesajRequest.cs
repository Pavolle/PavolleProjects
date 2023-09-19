using Pavolle.Core.ViewModels.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pavolle.Supplera.ViewModels.Request
{
    public class UyelikBasvuruMesajRequest:RequestBase
    {
        public long UyelikBasvuruOid { get; set; }
    }
}

using Pavolle.Core.ViewModels.Request;
using Pavolle.ESecim.Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pavolle.ESecim.ViewModels.Request
{
    public class ESecimRequestBase:RequestBase
    {
        public string KullaniciAdi { get; set; }
        public EKullaniciTipi? KullaniciTipi { get; set; }
        public long? FirmaOid { get; set; }
        public string SessionId { get; set; }
    }
}

using Pavolle.Core.ViewModels.Request;
using Pavolle.Supplera.Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pavolle.Supplera.ViewModels.Request
{
    public class UyelikBasvuruRequest:RequestBase
    {
        public string AdSoyad { get; set; }
        public EUyelikBasvuruTipi? UyelikBasvuruTipi { get; set; }
        public string KurumAdi { get; set; }
        public string Telefon { get; set; }
        public string Eposta { get; set; }
        public string OzelMesaj { get; set; }
    }
}

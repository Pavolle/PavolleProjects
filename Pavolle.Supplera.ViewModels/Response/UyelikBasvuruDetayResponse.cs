using Pavolle.Core.ViewModels.Response;
using Pavolle.Supplera.ViewModels.ViewData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pavolle.Supplera.ViewModels.Response
{
    public class UyelikBasvuruDetayResponse:ResponseBase
    {
        public UyelikBasvuruDetayViewData DetayBilgileri { get; set; }
        public List<UyelikBasvurusuIletisimGecmisiViewData> IletisimGecmisi { get; set; }
    }
}

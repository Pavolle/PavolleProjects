using Pavolle.Core.ViewModels.ViewData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pavolle.MessageService.ViewModels.ViewData
{
    public class CityViewData : ViewDataBase
    {

        public string Code { get; set; }
        public long CountryOid { get; set; }
        public string CountryName { get; set; }
        public string Name { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pavolle.MessageService.ViewModels.Model
{
    public class CityCacheModel
    {
        public long? CityOid { get; set; }
        public string Code { get; set; }
        public string TRName { get; set; }
        public string ENName { get; set; }
    }
}

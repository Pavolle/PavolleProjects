using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pavolle.MessageService.ViewModels.Model
{
    public class TranslateDataCacheModel
    {
        public long Oid { get; set; }
        public string Variable { get; set; }
        public string TR { get; set; }
        public string EN { get; set; }
    }
}

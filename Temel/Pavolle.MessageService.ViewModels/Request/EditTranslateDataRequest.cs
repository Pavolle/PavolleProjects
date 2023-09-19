using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pavolle.MessageService.ViewModels.Request
{
    public class EditTranslateDataRequest:MessageServiceRequestBase
    {
        public string TR { get; set; }
        public string EN { get; set; }
    }
}

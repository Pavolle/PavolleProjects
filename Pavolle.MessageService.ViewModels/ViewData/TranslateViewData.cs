using Pavolle.Core.ViewModels.ViewData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pavolle.MessageService.ViewModels.ViewData
{
    public class TranslateViewData : ViewDataBase
    {
        public string Variable { get; set; }
        public string EN { get; set; }
        public string TR { get; set; }
    }
}

using Pavolle.Core.Enums;
using Pavolle.Core.Utils;
using Pavolle.MessageService.Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pavolle.MessageService.Business.Manager
{
    public class TranslateManager:Singleton<TranslateManager>
    {
        private TranslateManager() { }

        public string? GetMessage(EMessageServiceMessageCode messageCode, ELanguage turkce)
        {
            throw new NotImplementedException();
        }

        internal string? GetXNotFoundMessage(ELanguage? language, string objectName)
        {
            throw new NotImplementedException();
        }
    }
}

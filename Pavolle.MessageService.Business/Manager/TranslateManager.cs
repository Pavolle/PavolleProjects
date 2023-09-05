using log4net;
using Pavolle.Core.Enums;
using Pavolle.Core.Utils;
using Pavolle.MessageService.Common.Enums;
using Pavolle.MessageService.ViewModels.Model;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pavolle.MessageService.Business.Manager
{
    public class TranslateManager:Singleton<TranslateManager>
    {
        static readonly ILog _log = LogManager.GetLogger(typeof(TranslateManager));
        private ConcurrentDictionary<string, TranslateDataCacheModel> _translateData;
        private TranslateManager() { }

        public string? GetMessage(EMessageServiceMessageCode messageCode, ELanguage turkce)
        {
            throw new NotImplementedException();
        }

        internal string? GetXNotFoundMessage(ELanguage? language, EMessageServiceMessageCode messageCode)
        {
            throw new NotImplementedException();
        }
    }
}

using log4net;
using Pavolle.Core.Enums;
using Pavolle.Core.Utils;
using Pavolle.MessageService.Common.Enums;
using Pavolle.MessageService.ViewModels.Criteria;
using Pavolle.MessageService.ViewModels.Model;
using Pavolle.MessageService.ViewModels.Request;
using Pavolle.MessageService.ViewModels.Response;
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

        public TranslateDataListResponse List(ListTranslateDataCriteria criteria)
        {
            throw new NotImplementedException();
        }

        public TranslateDataDetailResponse Detail(long? oid, MessageServiceRequestBase request)
        {
            throw new NotImplementedException();
        }

        public MessageServiceResponseBase Edit(long? oid, EditTranslateDataRequest request)
        {
            throw new NotImplementedException();
        }

        public string GetMessage(EMessageServiceMessageCode messageCode, ELanguage turkce)
        {
            throw new NotImplementedException();
        }

        internal string GetXNotFoundMessage(ELanguage? language, EMessageServiceMessageCode messageCode)
        {
            throw new NotImplementedException();
        }
    }
}

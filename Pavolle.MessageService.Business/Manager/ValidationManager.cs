using Pavolle.Core.Enums;
using Pavolle.Core.Utils;
using Pavolle.Core.ViewModels.Request;
using Pavolle.MessageService.Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Pavolle.MessageService.Business.Manager
{
    public class ValidationManager:Singleton<ValidationManager>
    {
        private ValidationManager() { }

        public string CheckString(string? text, bool nullable, int minLength, int maxLength, bool xssControl, EMessageServiceMessageCode messageCode, ELanguage language)
        {
            string response=null;
            if (!nullable)
            {
                if (string.IsNullOrWhiteSpace(text))
                {

                }
            }
            return response;
        }

        public string CheckEnum<T>(int? enumValue, bool nullable, EMessageServiceMessageCode messageCode, ELanguage language)
        {
            string response = null;
            return response;
        }

        public string CheckForNull(object objectData, EMessageServiceMessageCode messageCode, ELanguage language)
        {
            string response = null;
            if (objectData == null)
            {
                response = TranslateManager.Instance.GetXNotFoundMessage(language, messageCode);
            }
            return response;
        }

        internal string CheckForOidNull(long? oid, EMessageServiceMessageCode messageCode, ELanguage language)
        {
            string response = null;
            if(oid == null)
            {
                response = TranslateManager.Instance.GetXNotFoundMessage(language, messageCode);
            }
            return response;
        }
    }
}

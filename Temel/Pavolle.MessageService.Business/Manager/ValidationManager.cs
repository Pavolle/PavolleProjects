using Pavolle.Core.Enums;
using Pavolle.Core.Utils;
using Pavolle.MessageService.Common.Enums;

namespace Pavolle.MessageService.Business.Manager
{
    public class ValidationManager:Singleton<ValidationManager>
    {
        private ValidationManager() { }

        public string? CheckString(string? text, bool nullable, int minLength, int maxLength, bool xssControl, EMessageCode messageCode, ELanguage language)
        {
            string? response=null;
            if (!nullable)
            {
                if (string.IsNullOrWhiteSpace(text))
                {
                    response = string.Format(TranslateManager.Instance.GetXCannotBeLeftBlank(language, messageCode));
                }
            }
            return response;
        }

        public string? CheckEnum<T>(int? enumValue, bool nullable, EMessageCode messageCode, ELanguage language)
        {
            string? response = null;
            return response;
        }

        public string? CheckForNull(object objectData, EMessageCode messageCode, ELanguage language)
        {
            string? response = null;
            if (objectData == null)
            {
                response = TranslateManager.Instance.GetXNotFoundMessage(language, messageCode);
            }
            return response;
        }

        internal string? CheckForOidNull(long? oid, EMessageCode messageCode, ELanguage language)
        {
            string? response = null;
            if(oid == null)
            {
                response = TranslateManager.Instance.GetXNotFoundMessage(language, messageCode);
            }
            return response;
        }
    }
}

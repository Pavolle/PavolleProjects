using Pavolle.Core.Utils;
using System.Globalization;

namespace Pavolle.MobileCore.Utils
{
    public class HelperManager : Singleton<HelperManager>
    {
        private HelperManager() { }

        public string GetTwoLetterISOLanguageNameFromCulureInfo()
        {
            return CultureInfo.CurrentUICulture.TwoLetterISOLanguageName;
        }

        
    }
}

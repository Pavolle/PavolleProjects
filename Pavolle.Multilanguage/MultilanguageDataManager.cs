using Pavolle.Core.Utils;
using Pavolle.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pavolle.Multilanguage
{
    public class MultilanguageDataManager:Singleton<MultilanguageDataManager>
    {
        List<ELanguage> _desteklenenDiller;
        List<TranslateDataModel> _translateData;
        private MultilanguageDataManager() { }

        public void Setup(List<ELanguage> desteklenenDiller)
        {
            _desteklenenDiller = desteklenenDiller;
        }


    }
}

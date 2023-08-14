using Pavolle.Core.Enums;
using Pavolle.Core.Utils;
using Pavolle.Core.ViewModels.Response;
using Pavolle.Core.ViewModels.ViewData;
using Pavolle.PassCross.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pavolle.PassCross.Business
{
    public class LevelNameManager:Singleton<LevelNameManager>
    {
        private LevelNameManager()
        {

        }

        public LookupResponse GetLevelNameList(ELanguage language)
        {
            LookupResponse lookupResponse = new LookupResponse();

            if (language == ELanguage.Turkce)
            {
                lookupResponse = new LookupResponse
                {
                    DataList = new List<LookupViewData>
                    {
                        new LookupViewData{Key=(int)ELevel.Aday, Value="Aday"},
                        new LookupViewData{Key=(int)ELevel.Acemi, Value="Acemi"},
                        new LookupViewData{Key=(int)ELevel.Orta, Value="Orta"},
                        new LookupViewData{Key=(int)ELevel.Tecrubeli, Value="Tecrübeli"},
                        new LookupViewData{Key=(int)ELevel.Uzman, Value="Uzman"},
                        new LookupViewData{Key=(int)ELevel.Virtuoz, Value="Virtüöz"},
                        new LookupViewData{Key=(int)ELevel.Ustat, Value="Üstat"},
                        new LookupViewData{Key=(int)ELevel.Efsanevi, Value="Efsanevi"},
                        new LookupViewData{Key=(int)ELevel.UstunVarlik, Value="Üstün Varlık"}
                    }
                };
            }
            else if(language==ELanguage.Ingilizce)
            {
                lookupResponse = new LookupResponse
                {
                    DataList = new List<LookupViewData>
                    {
                        new LookupViewData{Key=(int)ELevel.Aday, Value="Novice"},
                        new LookupViewData{Key=(int)ELevel.Acemi, Value="Rookie"},
                        new LookupViewData{Key=(int)ELevel.Orta, Value="Intermediate"},
                        new LookupViewData{Key=(int)ELevel.Tecrubeli, Value="Experienced"},
                        new LookupViewData{Key=(int)ELevel.Uzman, Value="Expert"},
                        new LookupViewData{Key=(int)ELevel.Virtuoz, Value="Virtuoso"},
                        new LookupViewData{Key=(int)ELevel.Ustat, Value="Master"},
                        new LookupViewData{Key=(int)ELevel.Efsanevi, Value="Legendary"},
                        new LookupViewData{Key=(int)ELevel.UstunVarlik, Value="Supreme Operative"}
                    }
                };
            }

            return lookupResponse;
        }
    }
}

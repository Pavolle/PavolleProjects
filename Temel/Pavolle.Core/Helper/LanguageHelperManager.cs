using Pavolle.Core.Enums;
using Pavolle.Core.Utils;
using Pavolle.Core.ViewModels.Model;
using Pavolle.Core.ViewModels.Response;
using Pavolle.Core.ViewModels.ViewData;
using System.Globalization;

namespace Pavolle.Core.Helper
{
    public class LanguageHelperManager : Singleton<LanguageHelperManager>
    {
        List<LanguageNameModel> _languageNames;
        private LanguageHelperManager()
        {
            _languageNames = new List<LanguageNameModel>()
            {
                new LanguageNameModel
                {
                    Language=ELanguage.English,
                    English="English",
                    German="German",
                    Spanish="Spanish",
                    French="French",
                    Russian="Russian",
                    Turkish="Turkish",
                    Azerbaijani="Azerbaijani"
                },
                new LanguageNameModel
                {
                    Language=ELanguage.Turkish,
                    English="İnglizce",
                    German="Almanca",
                    Spanish="İspanyolca",
                    French="Fransızca",
                    Russian="Rusça",
                    Turkish="Türkçe",
                    Azerbaijani="Azerice"
                }
            };
        }

        public string GetTwoLetterISOLanguageNameFromCulureInfo()
        {
            return CultureInfo.CurrentUICulture.TwoLetterISOLanguageName;
        }

        public void Intialize(List<ELanguage> languages)
        {
            _languageNames = new List<LanguageNameModel>();
            foreach (var language in languages)
            {
                switch (language)
                {
                    case ELanguage.English:
                        _languageNames.Add(new LanguageNameModel
                        {
                            Language = ELanguage.English,
                            English = "English",
                            German = "German",
                            Spanish = "Spanish",
                            French = "French",
                            Russian = "Russian",
                            Turkish = "Turkish",
                            Azerbaijani = "Azerbaijani"
                        });
                        break;
                    case ELanguage.German:
                        _languageNames.Add(new LanguageNameModel
                        {
                            Language = ELanguage.German,
                            English = "Englisch",
                            German = "Deutsch",
                            Spanish = "Spanisch",
                            French = "Französisch",
                            Russian = "Russisch",
                            Turkish = "Türkisch",
                            Azerbaijani = "Aserbaidschanisch"
                        });
                        break;
                    case ELanguage.Spanish:
                        _languageNames.Add(new LanguageNameModel
                        {
                            Language = ELanguage.Spanish,
                            English = "English",
                            German = "German",
                            Spanish = "Spanish",
                            French = "French",
                            Russian = "Russian",
                            Turkish = "Turkish",
                            Azerbaijani = "Azerbaijani"
                        });
                        break;
                    case ELanguage.French:
                        _languageNames.Add(new LanguageNameModel
                        {
                            Language = ELanguage.French,
                            English = "English",
                            German = "German",
                            Spanish = "Spanish",
                            French = "French",
                            Russian = "Russian",
                            Turkish = "Turkish",
                            Azerbaijani = "Azerbaijani"
                        });
                        break;
                    case ELanguage.Russian:
                        _languageNames.Add(new LanguageNameModel
                        {
                            Language = ELanguage.Russian,
                            English = "Английский",
                            German = "Немецкий",
                            Spanish = "Испанский",
                            French = "Французский",
                            Russian = "Русский",
                            Turkish = "Турецкий",
                            Azerbaijani = "Aзербайджанский"
                        });
                        break;
                    case ELanguage.Turkish:
                        _languageNames.Add(new LanguageNameModel
                        {
                            Language = ELanguage.Turkish,
                            English = "İnglizce",
                            German = "Almanca",
                            Spanish = "İspanyolca",
                            French = "Fransızca",
                            Russian = "Rusça",
                            Turkish = "Türkçe",
                            Azerbaijani = "Azerice"
                        });
                        break;
                    case ELanguage.Azerbaijani:
                        _languageNames.Add(new LanguageNameModel
                        {
                            Language = ELanguage.Azerbaijani,
                            English = "İnglizcə",
                            German = "Almanca",
                            Spanish = "İspanca",
                            French = "Fransızca",
                            Russian = "Rusca",
                            Turkish = "Türkcə",
                            Azerbaijani = "Azərbaycan Dili"
                        });
                        break;
                    default:
                        break;
                }
            }
        }

        public LookupResponse LanguageLookupList(ELanguage language)
        {
            var response = new LookupResponse { DataList = new List<LookupViewData> { } };
            switch (language)
            {
                case ELanguage.English:
                    response.DataList = _languageNames.Select(t => new LookupViewData
                    {
                        IsDefault = true,
                        Key = (int)t.Language,
                        Value = t.English
                    }).ToList();
                    break;
                case ELanguage.German:
                    response.DataList = _languageNames.Select(t => new LookupViewData
                    {
                        IsDefault = true,
                        Key = (int)t.Language,
                        Value = t.German
                    }).ToList();
                    break;
                case ELanguage.Spanish:
                    response.DataList = _languageNames.Select(t => new LookupViewData
                    {
                        IsDefault = true,
                        Key = (int)t.Language,
                        Value = t.Spanish
                    }).ToList();
                    break;
                case ELanguage.French:
                    response.DataList = _languageNames.Select(t => new LookupViewData
                    {
                        IsDefault = true,
                        Key = (int)t.Language,
                        Value = t.French
                    }).ToList();
                    break;
                case ELanguage.Russian:
                    response.DataList = _languageNames.Select(t => new LookupViewData
                    {
                        IsDefault = true,
                        Key = (int)t.Language,
                        Value = t.Russian
                    }).ToList();
                    break;
                case ELanguage.Turkish:
                    response.DataList = _languageNames.Select(t => new LookupViewData
                    {
                        IsDefault = true,
                        Key = (int)t.Language,
                        Value = t.Turkish
                    }).ToList();
                    break;
                case ELanguage.Azerbaijani:
                    response.DataList = _languageNames.Select(t => new LookupViewData
                    {
                        IsDefault = true,
                        Key = (int)t.Language,
                        Value = t.Azerbaijani
                    }).ToList();
                    break;
                default:
                    break;
            }
            return response;
        }
    }
}

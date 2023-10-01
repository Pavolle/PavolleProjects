using Pavolle.Core.Enums;
using Pavolle.Core.Utils;
using Pavolle.PassCross.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pavolle.PassCross.Business
{
    internal class AdayQuestionManager :Singleton<AdayQuestionManager>
    {
        private AdayQuestionManager() { }


        private QuestionModel _question;
        ELanguage _language;

        public QuestionModel GenerateQuestion(ELanguage language)
        {
            _language= language;
            _question = new QuestionModel()
            {
                Tips = new List<QuestionTipModel>()
            };
            _question.Password = PasswordGeneratorManager.Instance.TekrarsizSayiUret(2);

            //1 ci kural => içeren bir rakam var ama yeri yanlış           
            //2 ci kural => tüm rakamlar yanlış                            
            //3 cu kural => 1 veya ikinci rakam var yeri de doğru
            //

            // Örnek 54 => 1 rakamla başla
            //   85 => 5 var yeri yanlış
            //   79 => hiç bir rakam doğru değil
            //   64 => 4 var ve yeri doğru

            //Örnek 34 => 2 rakamla başla
            // 47 4 var yeri yanlış
            // 12 hiç bir rakam yok
            // 39 3 var ve yeri doğru

            Random random = new Random();
            int baslangicIndexi = random.Next(0, 2);

            AdayBirinciKuralIcinSayiOlustur(baslangicIndexi);
            AdayIkinciKuralIcinSayiOlustur();
            AdayUcuncuKuralIcinSayiOlustur(baslangicIndexi);

            return _question;
        }

        private void AdayBirinciKuralIcinSayiOlustur(int baslangicIndexi)
        {
            string sonuc="";
            int birinciKuralSayisi = PasswordGeneratorManager.Instance.GonderilenSayidakiRakamlariIcermeyenRastgeleRakamOlustur(_question.Password);
            if (baslangicIndexi == 0)
            {
                sonuc = birinciKuralSayisi.ToString() + _question.Password[0];
            }
            else
            {
                sonuc = _question.Password[1] + birinciKuralSayisi.ToString();
            }
           
            string aciklama = "";
            switch (_language)
            {
                case ELanguage.English:
                    break;
                case ELanguage.German:
                    break;
                case ELanguage.Spanish:
                    break;
                case ELanguage.French:
                    break;
                case ELanguage.Russian:
                    break;
                case ELanguage.Turkish:
                    aciklama = _question.Password[baslangicIndexi] + " var, ama yeri yanlış!";
                    break;
                case ELanguage.Azerbaijani:
                    break;
                default:
                    break;
            }

            _question.Tips.Add(new QuestionTipModel
            {
                Password = sonuc,
                Tip = aciklama,
            });
        }

       

        private void AdayIkinciKuralIcinSayiOlustur()
        {
            string sonuc = "";
            sonuc += PasswordGeneratorManager.Instance.GonderilenSayidakiRakamlariIcermeyenRastgeleRakamOlustur(_question.Password).ToString();
            sonuc += PasswordGeneratorManager.Instance.GonderilenSayidakiRakamlariIcermeyenRastgeleRakamOlustur(_question.Password + sonuc.ToString());
            string tip = "";

            switch (_language)
            {
                case ELanguage.English:
                    break;
                case ELanguage.German:
                    break;
                case ELanguage.Spanish:
                    break;
                case ELanguage.French:
                    break;
                case ELanguage.Russian:
                    break;
                case ELanguage.Turkish:
                    tip = "Tüm karakterler yanlış!";
                    break;
                case ELanguage.Azerbaijani:
                    break;
                default:
                    break;
            }
            _question.Tips.Add(new QuestionTipModel
            {
                Password = sonuc,
                Tip = tip,
            });
        }

        
        private void AdayUcuncuKuralIcinSayiOlustur(int baslangicIndexi)
        {
            int index = 0; if (baslangicIndexi == 0) { index = 1; }
            string sonuc = "";
            int birinciKuralSayisi = PasswordGeneratorManager.Instance.GonderilenSayidakiRakamlariIcermeyenRastgeleRakamOlustur(_question.Password);
            if (index == 0)
            {
                sonuc = _question.Password[0] + birinciKuralSayisi.ToString();
            }
            else
            {
                sonuc = birinciKuralSayisi.ToString() + _question.Password[1];
            }

            string aciklama = "";
            switch (_language)
            {
                case ELanguage.English:
                    break;
                case ELanguage.German:
                    break;
                case ELanguage.Spanish:
                    break;
                case ELanguage.French:
                    break;
                case ELanguage.Russian:
                    break;
                case ELanguage.Turkish:
                    aciklama = _question.Password[index] + " var ve yeri doğru.";
                    break;
                case ELanguage.Azerbaijani:
                    break;
                default:
                    break;
            }

            _question.Tips.Add(new QuestionTipModel
            {
                Password = sonuc,
                Tip = aciklama,
            });
        }

        
    }
}

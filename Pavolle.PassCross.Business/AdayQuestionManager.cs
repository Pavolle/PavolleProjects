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
            var question = new QuestionModel()
            {
                Tips = new List<QuestionTipModel>()
            };
            question.Password = TekrarsizSayiUret(2);

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

            return question;
        }

        private void AdayBirinciKuralIcinSayiOlustur(int baslangicIndexi)
        {
            string parola = _question.Password;
            string birinciKuralSayisi = NinciBasamagiXOlmayanAmaXRakaminiIcerenVeParolayaEsitOlmayanSayiUret(baslangicIndexi, parola);
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
                    aciklama = parola[baslangicIndexi] + " rakamı var, ama yeri yanlış!";
                    break;
                case ELanguage.Azerbaijani:
                    break;
                default:
                    break;
            }

            _question.Tips.Add(new QuestionTipModel
            {
                Password = birinciKuralSayisi,
                Tip = aciklama,
            });
        }

        private string NinciBasamagiXOlmayanAmaXRakaminiIcerenVeParolayaEsitOlmayanSayiUret(int baslangicIndexi, string parola)
        {
            string sonuc = "";
            List<int> _kullanilmayanSayilar = new List<int> { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            for (int i = 0; i < parola.Length; i++)
            {
                int sayi = int.Parse(parola[i].ToString());
                _kullanilmayanSayilar.Remove(sayi);
            }
            Random random = new Random();

            if (baslangicIndexi == 0)
            {
                sonuc = _kullanilmayanSayilar[random.Next(0, _kullanilmayanSayilar.Count + 1)].ToString() + parola[0];
            }
            else
            {
                sonuc = parola[1] + _kullanilmayanSayilar[random.Next(0, _kullanilmayanSayilar.Count + 1)].ToString();
            }
            return sonuc;
        }

        private void AdayIkinciKuralIcinSayiOlustur()
        {
            string parola = _question.Password;
            string ikinciKuralSayisi = ParolaninIcermedigiRakamlardanSayiUret(parola);
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
                    tip = "Sayıdaki rakamların hiçbirini içermiyor!";
                    break;
                case ELanguage.Azerbaijani:
                    break;
                default:
                    break;
            }
            _question.Tips.Add(new QuestionTipModel
            {
                Password = ikinciKuralSayisi,
                Tip = tip,
            });
        }

        private string ParolaninIcermedigiRakamlardanSayiUret(string parola)
        {
            List<int> _kullanilmayanSayilar = new List<int> { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            for (int i = 0; i < parola.Length; i++)
            {
                _kullanilmayanSayilar.Remove(Convert.ToInt32(parola[i]));
            }
            Random random = new Random();
            string sonuc = "";
            for (int i = 0; i < parola.Length; i++)
            {
                var index = random.Next(0, _kullanilmayanSayilar.Count + 1);
                sonuc += _kullanilmayanSayilar[index].ToString();
                _kullanilmayanSayilar.Remove(_kullanilmayanSayilar[index]);
            }
            return sonuc;
        }

        private void AdayUcuncuKuralIcinSayiOlustur(int baslangicIndexi)
        {
            if (baslangicIndexi == 0) baslangicIndexi = 1;
            else baslangicIndexi = 0;
            string parola = _question.Password;
            string ucuncuKuralSayisi = NinciBasamagiXOlanVeParolayaEsitOlmayanSayiUret(baslangicIndexi, parola);
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
                    tip = parola[baslangicIndexi] + " rakamı var ve yeri doğru";
                    break;
                case ELanguage.Azerbaijani:
                    break;
                default:
                    break;
            }
            _question.Tips.Add(new QuestionTipModel
            {
                Password = ucuncuKuralSayisi,
                Tip = tip,
            });
        }

        private string NinciBasamagiXOlanVeParolayaEsitOlmayanSayiUret(int baslangicIndexi, string parola)
        {
            string sonuc = "";
            List<int> _kullanilmayanSayilar = new List<int> { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            for (int i = 0; i < parola.Length; i++)
            {
                int sayi = int.Parse(parola[i].ToString());
                _kullanilmayanSayilar.Remove(sayi);
            }
            Random random = new Random();


            if (baslangicIndexi == 0)
            {
                sonuc = parola[0] + _kullanilmayanSayilar[random.Next(0, _kullanilmayanSayilar.Count + 1)].ToString();
            }
            else
            {
                sonuc = _kullanilmayanSayilar[random.Next(0, _kullanilmayanSayilar.Count + 1)].ToString() + parola[1];
            }

            return sonuc;
        }

        public string TekrarsizSayiUret(int length)
        {
            List<int> _kullanilmayanSayilar = new List<int> { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            Random random = new Random();
            string sonuc = "";
            for (int i = 0; i < length; i++)
            {
                var index = random.Next(0, _kullanilmayanSayilar.Count + 1);
                sonuc += _kullanilmayanSayilar[index].ToString();
                _kullanilmayanSayilar.Remove(_kullanilmayanSayilar[index]);
            }
            return sonuc;
        }
    }
}

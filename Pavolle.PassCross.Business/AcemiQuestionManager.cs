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
    public class AcemiQuestionManager : Singleton<AcemiQuestionManager>
    {
        private AcemiQuestionManager() { }

        private QuestionModel _question;
        ELanguage _language;

        public QuestionModel GenerateQuestion(ELanguage language)
        {
            _language = language;
            _question = new QuestionModel()
            {
                Tips = new List<QuestionTipModel>(),
                Password=TekrarsizSayiUret(3)
            };


            /* 0ci rakamla başladığında
             şifre => 432
             Kural 1 546 => 4 var yeri yanlış
             Kural 2 690 => hiç bir rakam doğru değil!
             Kural 3 735 => 3 var ve yeri doğru
             Kural 4 258 => 2 var ve yeri yanlış
             */

            /* 1ci rakamla başladığında
             şifre => 432
             Kural 1 386 => 3 var yeri yanlış
             Kural 2 758 => hiç bir rakam doğru değil!
             Kural 3 465 => 4 var ve yeri doğru
             Kural 4 528 => 2 var ve yeri yanlış
             */

            /* 2ci rakamla başladığında
             şifre => 432
             Kural 1 286 => 2 var yeri yanlış
             Kural 2 910 => hiç bir rakam doğru değil!
             Kural 3 465 => 4  var ve yeri doğru
             Kural 4 563 => 3  var ve yeri yanlış
             */

            Random random = new Random();
            int baslangicIndexi = random.Next(0, 3);

            BirinciKuraliOlustur(baslangicIndexi);
            IkinciKuraliOlustur();
            UcuncuKuraliOlustur(baslangicIndexi);
            DorduncuKuraliOlustur(baslangicIndexi);

            return _question;
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

        private void BirinciKuraliOlustur(int baslangicIndexi)
        {
            string sonuc = "";
            int birinciRastgeleSayi = GonderilenSayidakiRakamlariIcermeyenRastgeleRakamOlustur(_question.Password);
            int ikinciRastgeleSayi = GonderilenSayidakiRakamlariIcermeyenRastgeleRakamOlustur(_question.Password + birinciRastgeleSayi.ToString());
            var random = new Random();
            int index = random.Next(0, 2);

            if (baslangicIndexi == 0)
            {
                if (index == 0)
                {
                    sonuc += birinciRastgeleSayi.ToString();
                    sonuc += _question.Password[0];
                    sonuc += ikinciRastgeleSayi;
                }
                else
                {
                    sonuc += birinciRastgeleSayi.ToString();
                    sonuc += ikinciRastgeleSayi;
                    sonuc += _question.Password[0];
                }
            }
            if(baslangicIndexi == 1)
            {
                if (index == 0)
                {
                    sonuc += _question.Password[1];
                    sonuc += birinciRastgeleSayi.ToString();
                    sonuc += ikinciRastgeleSayi;
                }
                else
                {
                    sonuc += birinciRastgeleSayi.ToString();
                    sonuc += ikinciRastgeleSayi;
                    sonuc += _question.Password[1];
                }
            }
            if(baslangicIndexi == 2)
            {
                if (index == 0)
                {
                    sonuc += _question.Password[2];
                    sonuc += birinciRastgeleSayi.ToString();
                    sonuc += ikinciRastgeleSayi;
                }
                else
                {
                    sonuc += birinciRastgeleSayi.ToString();
                    sonuc += _question.Password[2];
                    sonuc += ikinciRastgeleSayi;
                }
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
                    aciklama = _question.Password[baslangicIndexi].ToString() + " var. Yeri yanlış!";
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

        private int GonderilenSayidakiRakamlariIcermeyenRastgeleRakamOlustur(string parola)
        {
            List<int> _kullanilabilirSayilar = new List<int> { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            for (int i = 0; i < parola.Length; i++)
            {
                int sayi = int.Parse(parola[i].ToString());
                _kullanilabilirSayilar.Remove(sayi);
            }
            Random random = new Random();
            return _kullanilabilirSayilar[random.Next(0, _kullanilabilirSayilar.Count + 1)];
        }

        private void IkinciKuraliOlustur()
        {
            string sonuc = "";
            sonuc += GonderilenSayidakiRakamlariIcermeyenRastgeleRakamOlustur(_question.Password).ToString();
            sonuc += GonderilenSayidakiRakamlariIcermeyenRastgeleRakamOlustur(_question.Password + sonuc.ToString());
            sonuc += GonderilenSayidakiRakamlariIcermeyenRastgeleRakamOlustur(_question.Password + sonuc.ToString());

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
                    aciklama = "Hiçbir rakam doğru değil!";
                    break;
                case ELanguage.Azerbaijani:
                    break;
                default:
                    break;
            }

            _question.Tips.Add(new QuestionTipModel
            {
                Password = sonuc,
                Tip = aciklama
            });

        }

        private void UcuncuKuraliOlustur(int baslangicIndexi)
        {

            string sonuc = "";
            int birinciRastgeleSayi = GonderilenSayidakiRakamlariIcermeyenRastgeleRakamOlustur(_question.Password);
            int ikinciRastgeleSayi = GonderilenSayidakiRakamlariIcermeyenRastgeleRakamOlustur(_question.Password + birinciRastgeleSayi.ToString());
            if (baslangicIndexi == 0)
            {

            }
            if (baslangicIndexi == 1)
            {

            }
            if (baslangicIndexi == 2)
            {

            }
        }

        private void DorduncuKuraliOlustur(int baslangicIndexi)
        {
            if (baslangicIndexi == 0)
            {

            }
            if (baslangicIndexi == 1)
            {

            }
            if (baslangicIndexi == 2)
            {

            }
        }
    }
}

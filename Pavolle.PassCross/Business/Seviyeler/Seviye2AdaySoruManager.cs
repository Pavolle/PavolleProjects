using Pavolle.Core.Enums;
using Pavolle.Core.Utils;
using Pavolle.PassCross.Enums;
using Pavolle.PassCross.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pavolle.PassCross.Business.Seviyeler
{
    public class Seviye2AdaySoruManager:Singleton<Seviye2AdaySoruManager>, ISoruManager
    {
        private Seviye2AdaySoruManager()
        {

        }

        public Soru SoruOlustur(ELanguage dil)
        {
            string parola = SayiUretimManager.Instance.TekrarsizSayiUret(2);
            var response = new Soru
            {
                Zorluk = ELevel.Aday,
                Parola = parola
            };

            //                                                             
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

            Ipucu birincIpucu = BirinciKuralIcinSayiOlustur(baslangicIndexi, response.Parola, dil);
            Ipucu ikinciIpucu = IkinciKuralIcinSayiOlustur(response.Parola, dil);
            Ipucu ucuncuIpucu = UcuncuKuralIcinSayiOlustur(baslangicIndexi, response.Parola, dil);

            response.IpucuListesi = new List<Ipucu>
            {
                birincIpucu,
                ikinciIpucu,
                ucuncuIpucu
            };

            return response;
        }

        private Ipucu BirinciKuralIcinSayiOlustur(int baslangicIndexi, string parola, ELanguage dil)
        {
            string birinciKuralSayisi= NinciBasamagiXOlmayanAmaXRakaminiIcerenVeParolayaEsitOlmayanSayiUret(baslangicIndexi, parola);

            var ipucu = new Ipucu
            {
                Sayi = birinciKuralSayisi
            };

            if (dil == ELanguage.Turkish)
            {
                ipucu.Aciklama = parola[baslangicIndexi] + " rakamı var, ama yeri yanlış!";
            }

            return ipucu;
        }
        private Ipucu IkinciKuralIcinSayiOlustur(string parola, ELanguage dil)
        {
            string ikinciKuralSayisi = SayiUretimManager.Instance.ParolaninIcermedigiRakamlardanSayiUret(parola);
            var ipucu = new Ipucu
            {
                Sayi = ikinciKuralSayisi
            };

            if (dil == ELanguage.Turkish)
            {
                ipucu.Aciklama ="Sayıdaki rakamların hiçbirini içermiyor!";
            }

            return ipucu;
        }

        private Ipucu UcuncuKuralIcinSayiOlustur(int baslangicIndexi, string parola, ELanguage dil)
        {
            if (baslangicIndexi == 0) baslangicIndexi = 1;
            else baslangicIndexi = 0;
            string ucuncuKuralSayisi = NinciBasamagiXOlanVeParolayaEsitOlmayanSayiUret(baslangicIndexi, parola);

            var ipucu = new Ipucu
            {
                Sayi = ucuncuKuralSayisi
            };

            if (dil == ELanguage.Turkish)
            {
                ipucu.Aciklama = parola[baslangicIndexi] + " rakamı var ve yeri doğru";
            }

            return ipucu;
        }

        internal string NinciBasamagiXOlanVeParolayaEsitOlmayanSayiUret(int baslangicIndexi, string parola)
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

        internal string NinciBasamagiXOlmayanAmaXRakaminiIcerenVeParolayaEsitOlmayanSayiUret(int baslangicIndexi, string parola)
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


    }
}

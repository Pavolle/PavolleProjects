using Pavolle.Core.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pavolle.PassCross.Business
{
    public class PasswordGeneratorManager : Singleton<PasswordGeneratorManager>
    {
        private PasswordGeneratorManager() { }

        public string TekrarsizSayiUret(int length)
        {
            List<int> _kullanilmayanSayilar = new List<int> { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            Random random = new Random();
            string sonuc = "";
            for (int i = 0; i < length; i++)
            {
                var index = random.Next(0, _kullanilmayanSayilar.Count);
                sonuc += _kullanilmayanSayilar[index].ToString();
                _kullanilmayanSayilar.Remove(_kullanilmayanSayilar[index]);
            }
            return sonuc;
        }

        public int GonderilenSayidakiRakamlariIcermeyenRastgeleRakamOlustur(string parola)
        {
            List<int> _kullanilabilirSayilar = new List<int> { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            for (int i = 0; i < parola.Length; i++)
            {
                int sayi = int.Parse(parola[i].ToString());
                _kullanilabilirSayilar.Remove(sayi);
            }
            Random random = new Random();
            return _kullanilabilirSayilar[random.Next(0, _kullanilabilirSayilar.Count)];
        }
    }
}

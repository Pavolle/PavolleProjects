using Pavolle.Core.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pavolle.PassCross.Business
{
    public class SayiUretimManager:Singleton<SayiUretimManager>
    {
        private SayiUretimManager()
        {

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

        
        internal string ParolaninIcermedigiRakamlardanSayiUret(string parola)
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
    }
}

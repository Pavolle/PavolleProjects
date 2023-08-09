using Pavolle.Core.Utils;
using Pavolle.Security.Hash;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Pavolle.Security
{
    public class SecurityHelperManager : Singleton<SecurityHelperManager>
    {
        private string _key = "aT{s8x56f!'dfYuPAVOLLE-s9we3''3*0AspE#wr";

        public string NumericRasgteleKodOlustur(int uzunluk)
        {
            string kod = "";
            var random = new Random();
            for (int i = 0; i < uzunluk; i++)
            {
                kod += _rakamlar[random.Next(0, _rakamlar.Count)];
            }

            return kod;
        }

        private string _finalkey = "Y@AAghaUi7eRH#d-k*sw9Wb4XPAVOLLE-B2B2af/{&&+fZ";

        private SecurityHelperManager() { }

        List<char> _ozerlKarakterler = new List<char>
        {
            '?','.', '#', '+' , '*',  '-', '!', '$', '%', '@'
        };

        List<char> _rakamlar = new List<char>
        {
            '1', '2', '3' , '4',  '5', '6', '7', '8', '9'
        };
         

        List<char> _buyukHarfler = new List<char>
        {
            'A','B', 'C', 'D' , 'E',  'F', 'G', 'H', 'J','K','L', 'M', 'N' , 'P', 'R', 'S', 'T','U','V','Y','Z'
        };


        List<char> _kucukHarfler = new List<char>
        {
            'a','b', 'c', 'd' , 'e',  'f', 'g', 'h', 'j','k', 'm', 'n' , 'p', 'r', 's', 't','u','v','y','z'
        };

        public string SistemKullanicisiSifreUret()
        {
            //Örnek Şifre A@3-a2yF
            string sifre = "";
            var random = new Random();
            sifre += _buyukHarfler[random.Next(0, _buyukHarfler.Count)];
            sifre += _ozerlKarakterler[random.Next(0, _ozerlKarakterler.Count)];
            sifre += _rakamlar[random.Next(0, _rakamlar.Count)];
            sifre += _ozerlKarakterler[random.Next(0, _ozerlKarakterler.Count)];
            sifre += _kucukHarfler[random.Next(0, _kucukHarfler.Count)];
            sifre += _rakamlar[random.Next(0, _rakamlar.Count)];
            sifre += _kucukHarfler[random.Next(0, _kucukHarfler.Count)];
            sifre += _buyukHarfler[random.Next(0, _buyukHarfler.Count)];

            return sifre;

        }
        public string SistemYoneticisiSifreUret()
        {
            //Örnek Şifre A@3b-a2yF#5R
            string sifre = "";
            var random = new Random();
            sifre += _buyukHarfler[random.Next(0, _buyukHarfler.Count)];
            sifre += _ozerlKarakterler[random.Next(0, _ozerlKarakterler.Count)];
            sifre += _rakamlar[random.Next(0, _rakamlar.Count)];
            sifre += _kucukHarfler[random.Next(0, _kucukHarfler.Count)];
            sifre += _ozerlKarakterler[random.Next(0, _ozerlKarakterler.Count)];
            sifre += _kucukHarfler[random.Next(0, _kucukHarfler.Count)];
            sifre += _rakamlar[random.Next(0, _rakamlar.Count)];
            sifre += _kucukHarfler[random.Next(0, _kucukHarfler.Count)];
            sifre += _buyukHarfler[random.Next(0, _buyukHarfler.Count)];
            sifre += _ozerlKarakterler[random.Next(0, _ozerlKarakterler.Count)];
            sifre += _rakamlar[random.Next(0, _rakamlar.Count)];
            sifre += _buyukHarfler[random.Next(0, _buyukHarfler.Count)];

            return sifre;
        }

        public bool CheckPasswordForStandart(string password)
        {
            return Regex.Match(password, @"((?=.*\d)(?=.*[a-z])(?=.*[A-Z]).{8,})").Success;
        }

        public bool KarakterTekrariniKontrolEt(string password)
        {
            bool tekrarIceriyor = false;
            for (int i = 0; i < password.Length; i++)
            {
                if(i+1<password.Length && i + 2 < password.Length)
                {
                    if(password[i]==password[i+1] && password[i] == password[i + 2])
                    {
                        tekrarIceriyor = true;
                        return tekrarIceriyor;
                    }
                }
            }
            return tekrarIceriyor;
        }

        public bool ArdisikKarakterIceriyorMu(string password)
        {
            bool iceriyor = false;
            for (int i = 0; i < password.Length; i++)
            {
                if (i + 1 < password.Length && i + 2 < password.Length)
                {
                    short sonraki = Convert.ToInt16(password[i]);
                    char sonrakiKarakter = Convert.ToChar(sonraki+1);

                    short birsonraki = Convert.ToInt16(password[i+1]);
                    char birsonrakiKarakter = Convert.ToChar(birsonraki+1);

                    if (password[i + 1] == sonrakiKarakter && birsonrakiKarakter == password[i + 2])
                    {
                        iceriyor = true;
                        return iceriyor;
                    }
                }
            }
            return iceriyor;
        }

        //TODO Kullanıcı Adı değişmesi durumunda şifrenin tekrar oluşturulması ve güncellenmesi gerekir.
        public string GetEncryptedPassword(string password, string username)
        {
            var sha256 = new SHA256HashAlgorithm();
            var sha384 = new SHA384HashAlgorithm();
            var sha512 = new SHA512HashAlgorithm();

            var part1 = SecurityHelper.ReplaceHelper.ReplaceHashFunctionResult(sha256.ExecuteHMACHashAlgorithm(password, username));
            var part2 = SecurityHelper.ReplaceHelper.ReplaceHashFunctionResult(sha384.ExecuteHMACHashAlgorithm(password, password));
            var part3 = SecurityHelper.ReplaceHelper.ReplaceHashFunctionResult(sha512.ExecuteHMACHashAlgorithm(password, _key));

            var result1=
                SecurityHelper.StringHelper.Reverse(part1.Substring(0, 32))
                + part3.Substring(0, 64)
                + SecurityHelper.StringHelper.Reverse(part2.Substring(0, 32))
                + part3.Substring(64, 32)
                + SecurityHelper.StringHelper.Reverse(part1.Substring(32, 32))
                + part2.Substring(32, 32)
                + SecurityHelper.StringHelper.Reverse(part3.Substring(96, 32));

            return SecurityHelper.ReplaceHelper.ReplaceHashFunctionResult(sha256.ExecuteHMACHashAlgorithm(result1, _finalkey));
        }
    }
}

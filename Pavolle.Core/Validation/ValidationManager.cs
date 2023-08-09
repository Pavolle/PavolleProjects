using Pavolle.Core.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pavolle.Core.Validation
{
    public class ValidationManager:Singleton<ValidationManager>
    {
        private ValidationManager()
        {

        }

        //XSS Kontrolü

        public bool XSSAtaginaKarsiGuvenliMi(string metin)
        {
            bool guvenli=true;
            if(metin.Contains("<") && metin.Contains(">"))
            {
                return false;
            }
            if (metin.Contains(".js") || metin.Contains(".html") || metin.Contains("<script") || metin.Contains(".css"))
            {
                return false;
            }

            return guvenli;
        }

        public bool MetinBosMu(string metin)
        {
            return string.IsNullOrWhiteSpace(metin);
        }

        public bool MetinNKarakterdenFazlaMi(int n, string metin)
        {
            if(string.IsNullOrWhiteSpace(metin)) { return false; }
            return metin.Length > n;
        }
    }
}
